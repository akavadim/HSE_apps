// Ref3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <windows.h>

using namespace std;

void RunPaint() {
    STARTUPINFOW si = { };
    PROCESS_INFORMATION pi;
    BOOL result = CreateProcess(L"C:\\WINDOWS\\system32\\mspaint.exe", 
        NULL, NULL,NULL,FALSE, IDLE_PRIORITY_CLASS, NULL, NULL,  &si,  &pi);
    cout << "Priority: " <<GetPriorityClass(pi.hProcess)<<" Max priority: "<<IDLE_PRIORITY_CLASS<<endl;
    TerminateProcess(pi.hProcess, 0);
}

void RunWord() {
    UINT resCode = WinExec("C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE", SW_SHOW);
    if (resCode < 32)
    {
        LPSTR messageBuffer = nullptr;
        FormatMessageA(FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
            NULL, resCode, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPSTR)&messageBuffer, 0, NULL);
        throw exception(messageBuffer);
    }
}

DWORD WINAPI VeryHardFunction(void* obj) {
    int prior = (int)obj;
    int res = 0;
    for (int i = 0; i < 100; i += 1) {
        res++;
    }
    cout << res << " prior:" << prior << endl;
    return 0;
}

void SusAndResThread()
{
    HANDLE thread = CreateThread(NULL, 0, &VeryHardFunction, (void*)0, 0, NULL);
    HANDLE thread2 = CreateThread(NULL, 0, &VeryHardFunction, (void*)0, 0, NULL);
    TerminateThread(thread2, 0);
    SuspendThread(thread);
    SuspendThread(thread);
    Sleep(5000);
    ResumeThread(thread);
    Sleep(5000);
    ResumeThread(thread);
    Sleep(100);
}
void ThreadPriority() {

   SetThreadPriority(CreateThread(NULL, 0, &VeryHardFunction, (void*)1, 0, NULL), THREAD_PRIORITY_IDLE);
   SetThreadPriority(CreateThread(NULL, 0, &VeryHardFunction, (void*)2, 0, NULL), THREAD_PRIORITY_TIME_CRITICAL);
   Sleep(100);
}

void RunNotepad() {
    STARTUPINFOW si = { };
    PROCESS_INFORMATION pi;
    CreateProcess(L"C:\\Windows\\NOTEPAD.exe",
        NULL, NULL, NULL, FALSE, IDLE_PRIORITY_CLASS, NULL, NULL, &si, &pi);

    DWORD code;
    Sleep(100);
    GetExitCodeProcess(pi.hProcess, &code);
    cout <<"code: "<< code << endl;;
    Sleep(10000);
    TerminateProcess(pi.hProcess, 0);
    GetExitCodeProcess(pi.hProcess, &code);
    cout <<"code: " <<code << endl;
}

int main()
{
    RunPaint();
    RunWord();
    ThreadPriority();
    SusAndResThread();
    RunNotepad();
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
