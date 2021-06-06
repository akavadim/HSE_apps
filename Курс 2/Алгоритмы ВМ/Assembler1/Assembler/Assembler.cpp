// Assembler.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <iostream>
#include <cmath>
#include <string>
#include <bitset>

using namespace std;

int main()
{
	uint16_t input;
	int result = 0;
	cin >> input;	//до число не должно превышать 16 бит 

	__asm {
		xor ebx, ebx		//result
		xor eax, eax
		mov ax, input	//входное число
		mov si, 10
		xor cl, cl
	cycle:
		xor edx, edx	//обнуляем dx
		div si	//(dx, ax)/bx= ax - результат деления, dx - остаток
		shl edx, cl	//Сдвигаем edx влево на cl
		add cl, 4	//Добавляем к cl 4, тк каждый двоично десятичный код занимает 4 бита
		add ebx, edx	//добавляем к ebx, edx
		cmp ax,0	//сравниваем ax с 0
		jnz cycle	//если ax 0, то выходим из цикла, иначе переходим к cycle 
		mov result, ebx
	}
	std::cout << std::bitset<32>(result) << std::endl;
	system("pause");

	//float input;

	//char* res = new char[80];
	//char* dopCh = new char[80];

	//unsigned char exponenta;
	//uint32_t mantisa=0;
	//uint32_t integerMantisa=0;
	//uint32_t fractionalMantisa=0;
	//uint32_t index=0;
	//uint32_t index2 = 0;
	//uint32_t num = 3;
	//char startBitOfFractionalMantisa = 0;

	//cin >> input;

	//clock_t start, end;

	//start = clock();

	//_asm {
	//start1:
	//	mov edx, res
	//	mov eax, input;
	//	cmp eax,0
	//	jnz var_not_null
	//	mov[edx], '0'
	//	inc index
	//	jmp end_of_programm

	//var_not_null:
	//	btr eax,31
	//	jnc get_exponent
	//	mov [edx], '-'
	//	inc index

	//get_exponent:
	//	shr eax,23
	//	mov exponenta, al

	//get_mantisa:
	//	mov eax, input
	//	and eax, 00000000011111111111111111111111b
	//	//shl eax, 9
	//	//shr eax, 9
	//	bts eax, 23
	//	mov mantisa, eax

	//get_parts_of_mantisa:
	//	mov bl, exponenta
	//	sub bl, 127
	//	mov cl, 23
	//	jc exponenta_smoler_0

	//exponenta_bigger_0:
	//	sub cl, bl
	//	shr eax, cl
	//	mov integerMantisa, eax
	//	mov eax, mantisa
	//	mov bl, 32	
	//	sub bl, cl
	//	mov cl, bl
	//	shl eax, cl
	//	jmp end_of_parts_of_mantisa

	//exponenta_smoler_0:
	//	mov bl, exponenta
	//	mov cl, 127
	//	sub cl, bl
	//	dec cl		//-1
	//	shl eax,8	//
	//	shr eax, cl
	//	mov integerMantisa, 0

	//end_of_parts_of_mantisa:
	//	mov fractionalMantisa, eax
	//	//mov startBitOfFractionalMantisa, 31
	//	
	//integer_mantisa_to_string:
	//	mov eax, integerMantisa
	//	mov ebx, dopCh
	//	mov esi, 0
	//	mov edi, 10

	//cycel_inetger_mantisa_to_dopchar:
	//	mov edx, 0
	//	div edi
	//	add edx, 48
	//	mov [ebx+esi], dl
	//	inc esi
	//	cmp eax, 0
	//	jnz cycel_inetger_mantisa_to_dopchar
	//	mov index2, esi

	//dopCh_to_res:
	//	mov edx, res
	//	mov edi, index

	//cycle_dopCh_to_res:
	//	dec esi
	//	mov al, [ebx+esi]
	//	mov [edx+edi], al
	//	inc edi
	//	cmp esi,0
	//	jnz cycle_dopCh_to_res
	//	mov [edx+edi], '.'
	//	inc edi
	//	mov index, edi

	//fractional_mantisa_to_string:	//ebx - результат, edx:eax - для умножения, edi - курсор
	//	mov ebx, res
	//	mov edx, 0
	//	mov eax, fractionalMantisa
	//	mov ecx, 10
	//	
	//cycle_fractional_mantisa_to_string:
	//	mul ecx
	//	add dl, 48
	//	mov [ebx+edi], dl
	//	inc edi
	//	cmp eax,0
	//	jnz cycle_fractional_mantisa_to_string
	//	mov index, edi


	//end_of_programm:
	//	mov esi, index
	//	mov edx, res
	//	mov[edx + esi], 0	//установка окончания строки
	//}

	///*end = clock();

	//double time = ((double)end - start);

	//start = clock();

	//double time2;
	//string res2 = to_string(time);
	//end = clock();

	//time2 = ((double)end - start);*/

	//cout << res;
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
