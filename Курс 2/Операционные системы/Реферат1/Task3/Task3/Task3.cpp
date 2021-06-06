// Task3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <excpt.h>


void WithoutGlobal() {
	std::cout << "WithoutGlobal Start\n";
	int val = 0;
	__try {	//1
		val++;
		std::cout << "try_1 val=" << val << std::endl;
		__try {	//2
			val++;
			std::cout << "try_2 val=" << val << std::endl;
			__try {	//3
				val++;
				std::cout << "try_3 val=" << val << std::endl;
				val = val / 0;	//4. исключение, поиск обработчика
			}
			__except (EXCEPTION_EXECUTE_HANDLER)	//5. Глобальная раскрутка, но тк вложенных try нет раскрутка не происходит
			{
				//6.Выполнение блока
				val++; std::cout << "except_1 val=" << val << std::endl;
			}
		}
		__finally //7
		{
			val++; std::cout << "finally_1 val=" << val << std::endl;
		}
	}
	__except (EXCEPTION_EXECUTE_HANDLER)//не выполняется
	{
		val++; std::cout << "except_2 val=" << val << std::endl;
	}

	std::cout << "WithoutGlobal END val=" << val << std::endl;
}

void Global() {
	std::cout << "Global Start\n";
	int val = 0;
	__try {	//1
		val++;
		std::cout << "try_1 val=" << val << std::endl;
		__try {	//2
			val++;
			std::cout << "try_2 val=" << val << std::endl;
			__try {	//3
				val++;
				std::cout << "try_3 val=" << val << std::endl;
				__try {	//4
					val++;
					std::cout << "try_4 val=" << val << std::endl;
					val = val / 0;	//5. исключение, поиск обработчика
				}
				__finally	//8. выполняем finally
				{
					val++; std::cout << "finaly_1 val=" << val << std::endl;
				}
			}
			__except (EXCEPTION_CONTINUE_SEARCH)	//6. продолжаем поиск
			{
				val++; std::cout << "except_1 val=" << val << std::endl;
			}
		}
		__finally //9. выполняем finally
		{
			val++; std::cout << "finally_2 val=" << val << std::endl;
		}
	}
	__except (EXCEPTION_EXECUTE_HANDLER)	//7. Начинаем глобальную раскрутку
		//10.Выполняем обработчик
	{
		val++; std::cout << "except_2 val=" << val << std::endl;
	}

	std::cout << "Global END val=" << val << std::endl;
}

int main()
{
	Global();
	WithoutGlobal();
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
