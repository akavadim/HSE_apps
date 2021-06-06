// Ref3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <Windows.h>
#include <iostream>

using namespace std;


HANDLE mutexes[5];
HANDLE writeMutex = CreateMutex(NULL, FALSE, NULL);


DWORD WINAPI Phil(void *v)
{
	int number = (int)v;
	WaitForSingleObject(mutexes[number], INFINITE);
	WaitForSingleObject(mutexes[(number+1) % 5], INFINITE);
	WaitForSingleObject(writeMutex, INFINITE);
	cout << "Философ " << number << " начал есть" << endl;
	ReleaseMutex(writeMutex);
	Sleep(2000);
	WaitForSingleObject(writeMutex, INFINITE);
	cout << "Философ " << number << " закончил есть" << endl;
	ReleaseMutex(writeMutex);
	ReleaseMutex(mutexes[number]);
	ReleaseMutex(mutexes[number % 5]);

	return 0;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	HANDLE threads[5];

	for (int i = 0; i < 5; i++) {
		mutexes[i] = CreateMutex(NULL, FALSE, NULL);
	}
	for (int i = 0; i < 5; i++) {
		threads[i] = CreateThread(NULL, 0, Phil, (void*)(i), 0, NULL);
	}

	WaitForMultipleObjects(5, threads, TRUE, INFINITE);
	return 0;
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
