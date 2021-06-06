
// Task1_4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.

#include <iostream>
#include <excpt.h>
#include <stdio.h>
#include <Windows.h>

int g_zero = 0;

int Filter(unsigned long code, struct _EXCEPTION_POINTERS* ep) {
	int res;

	std::cout << "Filter block start\n";
	std::cout << "Error code: " << code << std::endl;
	std::cout << "Exception address: " << ep->ExceptionRecord->ExceptionAddress << std::endl;

	if (code == EXCEPTION_INT_DIVIDE_BY_ZERO && g_zero == 0)
	{
		std::cout << "Error: EXCEPTION_INT_DIVIDE_BY_ZERO" << std::endl;

		if (g_zero == 0) {
			std::cout << "g_zero==0 => g_zero=1" << std::endl;
			g_zero = 1;
			res = EXCEPTION_CONTINUE_EXECUTION;
		}
		else {
			res = EXCEPTION_CONTINUE_SEARCH;
		}
	}
	else if (code == EXCEPTION_ACCESS_VIOLATION)
	{
		std::cout << "Error: EXCEPTION_ACCESS_VIOLATION" << std::endl;
		res = EXCEPTION_EXECUTE_HANDLER;
	}
	else {
		std::cout << "Error: other\n";
		res = EXCEPTION_CONTINUE_SEARCH;
	}

	std::cout << "Filter block end\n";
	return res;
}

int main()
{
	int one = 1,
		res;

	char* pchar = NULL;

	__try {
		std::cout << "Try block start" << std::endl;
		
		__asm {
			mov eax, one
			mov edx, 0
			div g_zero
			mov res, eax
		}
		std::cout << "one/g_zero = " << res << std::endl;

		*pchar = 'd';

		std::cout << "Try block end." << std::endl;
	}
	__except (Filter(GetExceptionCode(), GetExceptionInformation()))
	{
		std::cout << "Error";
	}
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
