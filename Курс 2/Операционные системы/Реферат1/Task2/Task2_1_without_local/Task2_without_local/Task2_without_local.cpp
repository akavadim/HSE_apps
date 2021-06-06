// Task2_without_local.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <Windows.h>
#include <excpt.h>
#include <stdio.h>

void SimpleTryMethod() {
    std::cout << "SimpleTryMethod start" << std::endl;

    int one = 1,
        res;
    __try {
        res = one + one;
        std::cout << "Try block. re=one+one=" << res << std::endl;
    }
    __finally {
        res *= res;
        std::cout << "Finally block. res=res*res=" << res << std::endl;
    }
    std::cout << "SimpleTryMethod end. res="<<res << std::endl;
}

void LeaveMethod() {
    std::cout << "\nLeaveMethod start" << std::endl;
    int r = 1;
    __try {
        r++;
        std::cout << "Try block. r=r+1=" << r << " __leave;" << std::endl;
        __leave;
    }
    __finally {
        r++;
        std::cout << "Finally block. r=r+1=" << r << std::endl;
    }
    std::cout << "LeaveMethod end. r="<<r << std::endl;
}

int main()
{
    SimpleTryMethod();
    LeaveMethod();
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
