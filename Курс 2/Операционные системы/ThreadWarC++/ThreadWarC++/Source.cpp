
#include <locale.h>
#include <windows.h> 
#include <process.h>
#include <stdlib.h>
#include <time.h>
#include <stdio.h>
#include <tchar.h>

// ������� �������������
HANDLE screenlock; // ���������� ������ ���������� ������ ���� �����
HANDLE bulletsem;  // ����� ���������� ������ ��� ���� ������
HANDLE startevt;     // ���� ���������� � �������� ������� "�����" ��� "������"
HANDLE conin, conout;  // ����������� �������
HANDLE mainthread; // �������� ����� main
CRITICAL_SECTION gameover;
CONSOLE_SCREEN_BUFFER_INFO info; // ���������� � �������

// ���������� ��������� � ��������
long hit = 0;
long miss = 0;
char badchar[] = "-\\|/";

// �������� ���������� ����� �� n0 �� n1
int random(int n0, int n1)
{
    if (n0 == 0 && n1 == 1) return rand() % 2;
    return rand() % (n1 - n0) + n0;
}

// ������� �� ����� ������ � ������� � � � 

void writeat(int x, int y, wchar_t c)
{
    // ����������� ����� �� ����� ��� ������ ��������
    WaitForSingleObject(screenlock, INFINITE);
    COORD pos = { x,y };
    DWORD res;
    WriteConsoleOutputCharacter(conout, &c, 1, pos, &res);
    ReleaseMutex(screenlock);
}

// �������� ������� �� ������� (������� ����������� � ct) 
int getakey(int& ct)
{
    INPUT_RECORD input;
    DWORD res;
    while (1)
    {
        ReadConsoleInput(conin, &input, 1, &res);
        // ������������ ������ �������
        if (input.EventType != KEY_EVENT) continue;
        // ������������ ������� ���������� ������ 
        // ��� ���������� ������ �������
        if (!input.Event.KeyEvent.bKeyDown) continue;
        ct = input.Event.KeyEvent.wRepeatCount;
        return input.Event.KeyEvent.wVirtualKeyCode;
    }
}

// ���������� ������ � �������� ������� ������
int getat(int x, int y)
{
    wchar_t c;
    DWORD res;
    COORD org = { x,y };
    // ����������� ������ � ������� �� ��� ���, ���� ��������� �� ����� ���������
    WaitForSingleObject(screenlock, INFINITE);
    ReadConsoleOutputCharacter(conout, &c, 1, org, &res);
    ReleaseMutex(screenlock); // unlock
    return c;
}

// ���������� ���� � ��������� ���� � ��������� ������� ���������� ���� 
void score(void)
{
    wchar_t  s[128];
    swprintf_s(s, L"����� ������� - ���������:%d, ��������:%d", hit, miss);
    SetConsoleTitle(s);
    if (miss >= 1)
    {
        EnterCriticalSection(&gameover);
        SuspendThread(mainthread); // stop main thread
        MessageBox(NULL, L"���� ��������!", L"Thread War", MB_OK | MB_SETFOREGROUND);
        exit(0); // �� ������� �� ����������� ������
    }
}

// ��� ����� ���������� 
void badguy(void* _y)
{
    int y = (int)_y; // ��������� ���������� �
    int dir;
    int x;
    // �������� � ���������� �����, ������ � ���������� ������
    x = y % 2 ? 0 : info.dwSize.X;
    // ���������� ����������� � ����������� �� ��������� �������
    dir = x ? -1 : 1;
    // ���� ��������� ��������� � �������� ������
    while ((dir == 1 && x != info.dwSize.X) || (dir == -1 && x != 0))
    {
        int dly;
        BOOL hitme = FALSE;
        writeat(x, y, badchar[x % 4]);

        for (int i = 0; i < 15; i++)
        {
            Sleep(40);
            if (getat(x, y) == '*')
            {
                hitme = TRUE;
                break;
            }
        }
        writeat(x, y, ' ');

        if (hitme)
        {
            // � ���������� ������!
            MessageBeep(-1);
            InterlockedIncrement(&hit);
            score();
            _endthread();
        }
        x += dir;
    }
    // ��������� ������!
    InterlockedIncrement(&miss);
    score();
}

// ���� ����� ���������� ��������� ������� �����������
void badguys(void*)
{
    // ���� ������� � ������ ���� � ������� 15 ������
    WaitForSingleObject(startevt, 15000);
    // ������� ���������� �����
    // ������ 5 ������ ���������� ���� �������
    // ���������� � ������������ �� 1 �� 10
    while (1)
    {
        if (random(0, 100) < (hit + miss) / 25 + 20)
            // �� �������� ����������� �������������
            _beginthread(badguy, 0, (void*)(random(1, 10)));
        Sleep(1000); // ������ �������
    }
}

// ��� ����� ����, ������ ���� - ��� ��������� �����
DWORD WINAPI bullet(void* _xy_)
{
    COORD xy = *(COORD*)_xy_;
    if (getat(xy.X, xy.Y) == '*') return 0 ; // ����� ��� ���� ����
    // ���� ��������� 
    // ��������� �������
    // ���� ������� ����� 0, �������� �� ���������� 
    if (WaitForSingleObject(bulletsem, 0) == WAIT_TIMEOUT) return 0;

    while (--xy.Y)
    {
        writeat(xy.X, xy.Y, '*'); // ���������� ����
        Sleep(100);
        writeat(xy.X, xy.Y, ' ');    // ������� ����
    }

    // ������� ������.- �������� 1 � ��������
    ReleaseSemaphore(bulletsem, 1, NULL); 
    return 0;
}

// �������� ���������
int _tmain(int argc, _TCHAR* argv[])
{
    HANDLE me;
    // ��������� ���������� ����������
    conin = GetStdHandle(STD_INPUT_HANDLE);
    conout = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleMode(conin, ENABLE_WINDOW_INPUT);
    me = GetCurrentThread(); // �� �������� �������� ������������
    // �������� ���������������� �� �������� ���������� �������� ������
    DuplicateHandle(GetCurrentProcess(), me, GetCurrentProcess(), &mainthread, 0, FALSE, DUPLICATE_SAME_ACCESS);
    startevt = CreateEvent(NULL, TRUE, FALSE, NULL);
    screenlock = CreateMutex(NULL, FALSE, NULL);
    InitializeCriticalSection(&gameover);
    bulletsem = CreateSemaphore(NULL, 3, 3, NULL);
    GetConsoleScreenBufferInfo(conout, &info);

    // ���������������� ����������� ���������� �� �����
    score();
    // ��������� ��������� ��������� �����
    srand((unsigned)time(NULL));

    // ��������� ��������� ������� �����
    int y = info.dwSize.Y - 1;
    int x = info.dwSize.X / 2;
    // ��������� ����� badguys; ������ �� ������ �� ��� ���, 
    // ���� �� ���������� ������� ��� ������� 15 ������
    _beginthread(badguys, 0, NULL); // �������� ���� ����
    while (1)
    {
        int c, ct;
        writeat(x, y, '|'); // ���������� ����� 
        c = getakey(ct);   // �������� ������
        switch (c)
        {
        case VK_SPACE:
            static COORD xy;
            xy.X = x;
            xy.Y = y;
            SetThreadPriority(CreateThread(NULL, 0, &bullet, (void*)&xy, 0, NULL), THREAD_PRIORITY_TIME_CRITICAL);
            Sleep(100); // ���� ���� ����� ������� �� ��������� ����������
            break;
        case VK_LEFT:  // ������� "�����!"
            SetEvent(startevt);    // ����� badguys �������� 
            writeat(x, y, ' ');      // ������ � ������ ����� 
            while (ct--)        // �������������
                if (x) x--;
            break;
        case VK_RIGHT: // ������� "������!"; ������ �� ��
            SetEvent(startevt);
            writeat(x, y, ' ');
            while (ct--)
                if (x != info.dwSize.X - 1) x++;
            break;
        }
    }
}
