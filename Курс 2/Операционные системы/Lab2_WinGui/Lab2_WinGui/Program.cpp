#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <tchar.h>

const int SetkaNxN = 20;
const int StartWidth = 320;
const int StartHeight = 240;
const TCHAR* LpszClassName = _T("Lab2WinGuiClass");
const TCHAR* LpWindowName = _T("Lab2 Windows Gui");

HBRUSH currentBrush = CreateSolidBrush(RGB(0, 0, 255));
HWND hwnd;
HDC hdc;
BOOL drawPoint = false;
BOOL setka = false;
RECT clientRect;
RECT targerRect;
POINTS mousePoints;
PAINTSTRUCT paintStruct;

POINT points[1000];
int nPoints = 0;

void RunNotepad(void)
{
    STARTUPINFO sInfo;
    PROCESS_INFORMATION pInfo;

    ZeroMemory(&sInfo, sizeof(STARTUPINFO));

    CreateProcess(_T("C:\\Windows\\Notepad.exe"),
        NULL, NULL, NULL, FALSE, 0, NULL, NULL, &sInfo, &pInfo);
}

bool AddPoint(int x, int y) {
    int xLeft = x - x % SetkaNxN + 1;
    int yTop = y - y % SetkaNxN + 1;
    int xRight = xLeft + SetkaNxN - 2;
    int yBottom = yTop + SetkaNxN - 2;

    for (int i = 0; i < nPoints; i++) {
        if (points[i].x == xLeft && points[i].y == yTop)
            return false;
    }
    points[nPoints].x = xLeft;
    points[nPoints].y = yTop;
    nPoints++;
    drawPoint = true;
    SetRect(&targerRect, xLeft, yTop, xRight, yBottom);
    InvalidateRect(hwnd, &targerRect, false);
    return true;
}

void SetRandomBackground(void) {
    DeleteObject(currentBrush);
    currentBrush = CreateSolidBrush(RGB(rand()%256, rand() % 256, rand() % 256));
    SetClassLongPtr(hwnd, GCLP_HBRBACKGROUND, (LONG)currentBrush);
    InvalidateRect(hwnd, NULL, TRUE);
}

int LButtonDown(WPARAM wParam, LPARAM lParam) {
    mousePoints = MAKEPOINTS(lParam);
    AddPoint(mousePoints.x, mousePoints.y);
    return 0;
}

int PaintWm(WPARAM wParam, LPARAM lParam) {
    hdc = BeginPaint(hwnd, &paintStruct);
    if (drawPoint) {
        SelectObject(hdc, GetStockObject(LTGRAY_BRUSH));
        Ellipse(hdc, targerRect.left, targerRect.top, targerRect.right, targerRect.bottom);
        drawPoint = false;
    }

    if (!setka) {
        HPEN redPen = CreatePen(PS_SOLID, 1, RGB(255, 0, 0));
        SelectObject(hdc, redPen);
        for (int i = SetkaNxN; i < clientRect.right || i < clientRect.bottom; i += SetkaNxN)
        {
            if (i < clientRect.right)
            {
                MoveToEx(hdc, i, 0, NULL);
                LineTo(hdc, i, clientRect.bottom);
            }
            if (i < clientRect.bottom) {
                MoveToEx(hdc, 0, i, NULL);
                LineTo(hdc, clientRect.right, i);
            }
        }
        DeleteObject(redPen);
        SelectObject(hdc, GetStockObject(LTGRAY_BRUSH));
        for (int i = 0; i < nPoints; i++) {
            int xLeft = points[i].x - points[i].x % SetkaNxN + 1;
            int yTop = points[i].y - points[i].y % SetkaNxN + 1;
            int xRight = xLeft + SetkaNxN - 2;
            int yBottom = yTop + SetkaNxN - 2;
            Ellipse(hdc, xLeft, yTop, xRight, yBottom);
        }
    }

    EndPaint(hwnd, &paintStruct);
    return 0;
}

LRESULT CALLBACK Lab2WinGuiProcedure(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam) {
    switch (message)
    {
    case WM_DESTROY:
        PostQuitMessage(0);
        return 0;

    case WM_SIZE:
        GetClientRect(hwnd, &clientRect);
        setka = false;
        return 0;

    case WM_LBUTTONDOWN:
        return LButtonDown(wParam, lParam);

    case WM_PAINT:
        return PaintWm(wParam, lParam);

    case WM_KEYDOWN:
        if (wParam == VK_ESCAPE or (wParam == 'Q' and (GetKeyState(VK_CONTROL) < 0)))
            PostQuitMessage(0);
        else if (wParam == 'C' and (GetKeyState(VK_SHIFT) < 0))
            RunNotepad();
        else if (wParam == VK_RETURN)
            SetRandomBackground();
        return 0;
    }

    return DefWindowProc(hwnd, message, wParam, lParam);
}

int CALLBACK WinMain(
    _In_ HINSTANCE hInstance,
    _In_opt_ HINSTANCE hPrevInstance,
    _In_ LPSTR     lpCmdLine,
    _In_ int       nCmdShow)
{
    WNDCLASS wndclass = { };
    HBRUSH blueBrush = CreateSolidBrush(RGB(0, 0, 255));

    wndclass.hInstance = hInstance;
    wndclass.lpszClassName = LpszClassName;
    wndclass.lpfnWndProc = Lab2WinGuiProcedure;
    wndclass.hbrBackground = currentBrush;

    if (!RegisterClass(&wndclass)) {
        return EXCEPTION_ACCESS_VIOLATION;
    }
    
    hwnd = CreateWindow(LpszClassName, LpWindowName, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 
        StartWidth, StartHeight, HWND_DESKTOP, NULL, hInstance, NULL);

    ShowWindow(hwnd, nCmdShow);

    while (true) {
        MSG message;
        BOOL messageRes = GetMessage(&message, NULL, 0, 0);
        if (messageRes == 0)
            break;
        if (messageRes == -1)
        {
            MessageBox(NULL, L"GetMessage Error", L"Error", 0);
            break;
        }

        TranslateMessage(&message);
        DispatchMessageW(&message);
    }

    DeleteObject(currentBrush);
    DestroyWindow(hwnd);
    UnregisterClass(LpszClassName, hInstance);
}