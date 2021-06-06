// Ref4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <windows.h>

using namespace std;

void MallocFunction() {
    char header[] = "MallocFunction - ";
    int n = 10;
    int* arr = (int*)malloc(n * sizeof(int));
    if (arr == NULL)
        cout << header << "Не удалось выделить память" << endl;

    cout << header << "arr: ";
    for (int i = 0; i < n; i++)
        cout << arr[i] << " ";
    cout << endl;
    free(arr);
}

void CallocFunction() {
    char header[] = "CallocFunction - ";
    int n = 10;
    int* arr = (int*)calloc(n, sizeof(int));

    cout << header << "arr: ";
    for (int i = 0; i < n; i++)
        cout << arr[i] << " ";
    cout << endl;
    free(arr);
}

void ReallocFunction() {
    char header[] = "ReallocFunction - ";
    int n = 10;
    int* arr = (int*)malloc(n * sizeof(int));

    cout << header << "arr: ";
    for (int i = 0; i < n; i++) {
        arr[i] = i + 1;
        cout << arr[i] << " ";
    }
    cout << endl;

    n = 10000;
    int* newArr = (int*)realloc(arr, n * sizeof(n));

    cout << header<<"newArr: ";
    for (int i = 0; i < 15; i++)
        cout << newArr[i] << " ";
    cout << endl;

    cout << header << "arr = " << arr << " newArr = " << newArr << endl;    //arr - висячая ссылка
    free(newArr);
}

void VirtualAllocFunction() {
    char header[] = "VirtualAllocFunction - ";
    int n = 100000;
    int* arr =(int*)VirtualAlloc(NULL, n*sizeof(int),MEM_RESERVE,PAGE_READWRITE);
    VirtualAlloc(arr, 10 * sizeof(int),MEM_COMMIT, PAGE_READWRITE);

    cout << header << "arr[0-9]: ";
    for (int i = 0; i < 10; i++) {
        if (i < 5)
            arr[i] = i + 1;
        cout << arr[i] << " ";
    }
    cout << endl;
    VirtualAlloc(arr, n * sizeof(int), MEM_COMMIT, PAGE_READWRITE);
    cout << header << "arr[0-9]: ";
    for (int i = 0; i < 10; i++) {
        cout << arr[i] << " ";
    }
    arr[99999] = 33;
    cout << endl << header << "arr[99999] = " << arr[99999] << endl;
    VirtualFree(arr, 0, MEM_DECOMMIT);
    cout << header << "arr[0-9]: ";
    VirtualAlloc(arr, n * sizeof(int), MEM_COMMIT, PAGE_READWRITE);
    for (int i = 0; i < 10; i++) 
        cout << arr[i] << " ";
    cout << endl;
    VirtualFree(arr, 0, MEM_RELEASE);
}

void Stack() {
    int a;
    int b = 3;
    int c[3];
}

void FileMap() {
    TCHAR fileName[] = L"exmple.txt";
    HANDLE hFile = CreateFile(fileName, GENERIC_READ, 0, nullptr, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, nullptr);
    DWORD size = GetFileSize(hFile, nullptr);
    HANDLE hMapping = CreateFileMapping(hFile, nullptr, PAGE_READONLY, 0, 0, nullptr);
    char* mapAddress = (char*)MapViewOfFile(hMapping, FILE_MAP_READ, 0, 0, size);
    for (int i = 0; i < 5; i++) {
        cout << "Address: " << &mapAddress+i << " Value: " << mapAddress[i] << endl;
    }

    CloseHandle(hMapping);
    CloseHandle(hFile);   
}

int StackOverflow(int i) {
    if (i > 0)
        return StackOverflow(--i) + 1;
    return 0;
}

int main()
{
    MallocFunction();
    CallocFunction();
    ReallocFunction();
    VirtualAllocFunction();
    FileMap();
    //ошибки
    std::cout << StackOverflow(5000);
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
