// AssemblerAuto.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <windows.h>
#include <time.h>

using namespace std;

void printIntCifr(uint16_t input) {
	const uint16_t bytesSize = 10;
	uint8_t bytes[bytesSize];
	const uint16_t resSize = 4;
	uint8_t res[resSize];

	__asm {
	pr_start:
			call set_bytes
			mov cx, resSize
			dec cx
			mov ax, input
			mov di, 10

			pr_start_cycle :
			xor dx, dx
			div di
			push dx
			call bytes_by_index
			mov dl, [ebx]	
			push cx
			call res_by_index
			mov[ebx], dl

			dec cx
			cmp cx, -1
			jnz pr_start_cycle

			jmp pr_end

		set_bytes:
			push ebx

			lea ebx, bytes
			mov [ebx], 01110111b	//0
			inc ebx
			mov [ebx], 01100000b	//1
			inc ebx
			mov [ebx], 00111110b	//2
			inc ebx
			mov [ebx], 01111100b	//3
			inc ebx
			mov [ebx], 01101001b	//4
			inc ebx
			mov [ebx], 01011101b	//5
			inc ebx
			mov [ebx], 01011111b	//6
			inc ebx
			mov [ebx], 01100100b	//7
			inc ebx
			mov [ebx], 01111111b	//8
			inc ebx
			mov [ebx], 01111101b	//9

			pop ebx
			ret



		
			//ebx bytes_by_index(word index)
			//ebx - адрес на элемент
			//index - индекс нужного элемета
		bytes_by_index:
			push edi
			mov edi, esp
			push ecx

			
			lea ebx, bytes
			mov cx, [edi + 8]
			movzx ecx, cx
			add ebx, ecx

			pop ecx
			pop edi
			ret 2

			//ebx res_by_index(word index)
			//ebx - адрес на элемент
			//index - индекс нужного элемета
		res_by_index:
			push edi
			mov edi, esp
			push ecx

			lea ebx, res
			mov cx, [edi + 8]
			movzx ecx, cx
			add ebx, ecx

			pop ecx
			pop edi
			ret 2

			pr_end:
	}

	system("cls");
	string resUp = "";
	string resMiddle = "";
	string resDown = "";

	for (size_t i = 0; i < resSize; i++)
	{
		int c[7];
		uint8_t copyRes = res[i];
		for (int i = 0; i < 7; i++)
		{
			c[i] = copyRes % 2;
			copyRes = copyRes / 2;
		}

		resUp += " ";
		resUp += (c[2] == 1 ? "_" : " ");
		resUp += " ";
		resMiddle += (c[0] == 1 ? "|" : " ");
		resMiddle += (c[3] == 1 ? "_" : " ");
		resMiddle += (c[5] == 1 ? "|" : " ");
		resDown += (c[1] == 1 ? "|" : " ");
		resDown += (c[4] == 1 ? "_" : " ");
		resDown += (c[6] == 1 ? "|" : " ");
	}
	cout << resUp + "\n" + resMiddle + "\n" + resDown;
}

int main()
{
	//time_t seconds = time(NULL);
	//tm* timeinfo = localtime(&seconds);

	//for (int i = 0; i < 10000; i++) {
		printIntCifr(90);
	//}
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
