// Task2_2_loacl_break_continue.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <Windows.h>
#include <excpt.h>
#include <stdio.h>


void ForMethod() {
    std::cout << "ForMethod start" << std::endl;
    int c = 1,
        res = 0;
    for (int i = 5; i < 10; i++) {
        __try {
            if (i < 7) {
                c++;
                std::cout << "Continue\n";
                continue;
            }
            else {
                c += 2;
                std::cout << "Break\n";
                break;
            }
        }
        __finally {
            res += c;
            std::cout << "Finally block. i=" << i << " c=" << c << " res=res+c=" << res << std::endl;
        }
    }
    std::cout << "ForMethod end. res = " << res << std::endl;
}

int ReturnMethod() {
    std::cout << "\nReturnMethod start" << std::endl;
    int r = 1;
    __try {
        r++;
        std::cout << "Try block. r=r+1=" << r << " return r;" << std::endl;
        return r;
    }
    __finally {
        r++;
        std::cout << "Finally block. r=r+1=" << r << std::endl;
    }
}

void GoToMethod() {
    std::cout << "\nGoToMethod start" << std::endl;
    int r = 1;
    __try {
        r++;
        std::cout << "Try block. r=r+1=" << r << " goto label;" << std::endl;
        goto label;
    }
    __finally {
        r++;
        std::cout << "Finally block. r=r+1=" << r << std::endl;
    }

    label:

    std::cout << "GoToMethod end. r=" <<r<< std::endl;
}

int main()
{
    ForMethod();
    int r = ReturnMethod();
    std::cout << "ReturnMethod end r=" <<r << std::endl;
    GoToMethod();
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
