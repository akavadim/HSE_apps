// Assembler2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

using namespace std;

int main()
{
	const uint32_t Lenght1 = 8;
	const uint32_t Lenght2 = 8;
	uint8_t array[Lenght1][Lenght2];
	uint8_t* chessboard = array[0];
	uint32_t queenPositionX;
	uint32_t queenPositionY;
	uint32_t summArray = 0;

	uint8_t maxPositions[10][2];
	uint32_t  amountMaxPoints = 0;
	uint32_t maxSum = 0;


	cin >> queenPositionX>>queenPositionY;

	//Функции:
	//ebx chessboard_by_index(x, y) получение по индексу x строки y столбца. Результат: адрес на элемент
	//void set_by_diog(x,y) устанавливает диагональные линии по позиции x,y в значение 1
	//void set_by_vert_and_hor(x, y) устанавливает вертикальную и горизонтальную линии по позиции x,y в значение 1
	//ebx array_sum() Результат: сумма элементов массива
	//void array_reset() устанавливает все элементы массива в 0
	//void set_queen_position(x, y) зануляет поле, устанавливает королеву на x, y и заполняет клетки под удар еденицами
	//ah, al get_most_controlled_area() находит самую контролируемую клетку, x - ah, y - al

	__asm {
	start:
		dec queenPositionX
		dec queenPositionY

		call get_most_controlled_sum
		mov maxSum, eax
		push eax
		call set_maxPositions_by_sum

		push queenPositionX
		push queenPositionY
		call set_queen_position
		call array_sum
		mov summArray, eax
		jmp end_pr


	set_maxPositions_by_sum:	//void set_posotions_by_sum(sum(32bit)) находит все клетки с суммой элементов sum 
		push edi
		mov edi, esp
		push esi
		push eax
		push ebx
		push ecx
		push edx

		xor edx, edx
		xor esi, esi	//Хранится количество добавленнных точек
		lea ebx, maxPositions

	cycle_set_maxPosotopns1:
		xor ecx, ecx

	cycle_set_maxPosotopns2:
		push edx
		push ecx
		call set_queen_position
		call array_sum
		cmp eax, [edi+8]
		js not_equils
		mov [ebx], dl
		inc ebx
		mov [ebx], cl
		inc ebx
		inc esi

	not_equils:
		inc ecx
		cmp ecx, Lenght2
		jnz cycle_set_maxPosotopns2
		
		inc edx
		cmp edx, Lenght1
		jnz cycle_set_maxPosotopns1

		mov amountMaxPoints,esi

		pop edx
		pop ecx
		pop ebx
		pop eax
		pop esi
		pop edi
		ret 4

	get_most_controlled_sum:	//eax get_most_controlled_sum() находит сумму самой контролируемой клетки, рез в eax
		push ecx
		push edx
		push ebx
		
		xor edx,edx
		xor ebx,ebx	//в ebx самое большое значение

	loop_cycle1:
		xor ecx, ecx

	loop_cycle2:
		push edx
		push ecx
		call set_queen_position
		call array_sum
		cmp ebx, eax		//Сделать через cmp-----------------------------------------СДЕЛАНО
		jns not_bigger
		mov ebx, eax

	not_bigger:
		inc ecx
		cmp ecx, Lenght2
		jnz loop_cycle2
		
		inc edx
		cmp edx, Lenght1
		jnz loop_cycle1
		mov eax, ebx

		pop ebx 
		pop edx
		pop ecx
		ret

	set_queen_position:		//void set_queen_position(x, y) зануляет поле, устанавливает королеву на x, y и заполняет клетки под удар еденицами
		push edi
		mov edi, esp
		push ebx

		call array_reset
		push [edi+12]
		push [edi+8]
		push dword ptr[1]
		push dword ptr[0]
		call set_line

		push [edi+12]
		push [edi+8]
		push dword ptr[0]
		push dword ptr[1]
		call set_line

		push [edi+12]
		push [edi+8]
		push dword ptr[-1]
		push dword ptr[0]
		call set_line

		push [edi+12]
		push [edi+8]
		push dword ptr[0]
		push dword ptr[-1]
		call set_line

		push [edi+12]
		push [edi+8]
		push dword ptr[1]
		push dword ptr[1]
		call set_line

		push [edi+12]
		push [edi+8]
		push dword ptr[1]
		push dword ptr[-1]
		call set_line

		push [edi+12]
		push [edi+8]
		push dword ptr[-1]
		push dword ptr[1]
		call set_line

		push [edi+12]
		push [edi+8]
		push dword ptr[-1]
		push dword ptr[-1]
		call set_line

		pop ebx
		pop edi
		ret 8


	array_reset:			//Устанавливает все элементы массива в 0
		push edx
		mov edx, esp
		push ecx
		push ebx

		mov ebx, chessboard
		mov ecx, 64

	cycle_array_reset:
		mov [ebx], 0
		inc ebx
		loop cycle_array_reset

		pop ebx
		pop ecx
		pop edx
		ret 

	array_sum:				//Считает сумму элементов массива, результат в eax
		push esi
		push edi
		push ecx
		push ebx

		xor esi, esi
		xor eax, eax

	loop_array_sum_1:
		xor ecx, ecx

	loop_array_sum_2:
		push esi
		push ecx
		call chessboard_by_index

		mov bl, [ebx]		//???????????????????????????????????????????????????????????????????????????????????????????????????????
		movzx ebx, bl
		add eax, ebx

		inc ecx
		cmp ecx, Lenght2
		jnz loop_array_sum_2

		inc esi
		cmp esi, Lenght1
		jnz loop_array_sum_1

		pop ebx
		pop ecx
		pop edi
		pop esi
		ret

	set_line:	//void set_queen_lines(x, y, deltaX, delataY) x- строка, y - столбец, deltaX - (от -1 до 1), DeltaY(от -1 до 1)
		push edi
		mov edi, esp
		push eax
		push ebx
		push ecx
		push edx
		//В ecx будет количество клеток, в которых нужно будет поставить 1 по DeltaX и DeltaY
		// распределение по меткам в зависимости от (deltaX, DeltaY)
		cmp dword ptr[edi+12], 0
		jnz delta_x_not_zero
		cmp dword ptr[edi+8], 1
		jz deltes_0_1
		jmp deltes_0_m1

	delta_x_not_zero:
		cmp dword ptr[edi + 12], 1
		jnz delta_x_minus
		cmp dword ptr[edi+8], 1
		jz deltes_1_1
		cmp dword ptr[edi+8],0
		jz deltes_1_0
		jmp deltes_1_m1

	delta_x_minus:
		cmp dword ptr[edi+8], 1
		jz deltes_m1_1
		cmp dword ptr[edi+8],0
		jz deltes_m1_0
		jmp deltes_m1_m1

		//Если дельты (1,0) - право
	deltes_1_0:
		mov ecx, Lenght1
		sub ecx, [edi+16]		//индекс столбца
		dec ecx
		jmp deltes_end
		//Если дельты (0,1) - верх
	deltes_0_1:
		mov ecx, [edi+20]	//индекс строки
		jmp deltes_end
		//Если дельты (-1,0) - лево
	deltes_m1_0:
		mov ecx, [edi+16]	//индекс столбца
		jmp deltes_end
		//Если дельты (0,-1) - низ
	deltes_0_m1:
		mov ecx, Lenght2
		sub ecx, [edi+20]
		dec ecx
		jmp deltes_end
		//Если дельты (1,1) - верх-право
	deltes_1_1:
		mov ecx, Lenght1	//действие из дельты 1,0
		sub ecx, [edi+16]
		dec ecx
		mov eax, [edi+20]	//действие из 0,1
		cmp eax, ecx
		jnc deltes_end
		mov ecx, eax
		jmp deltes_end
		//Если дельты (1,-1) - право-низ
	deltes_1_m1:
		mov eax, Lenght1	//действие из дельты 1,0
		sub eax, [edi+16]
		dec eax
		mov ecx, Lenght2	//действие из 0, -1
		sub ecx, [edi+20]
		dec ecx
		cmp eax, ecx
		jnc deltes_end
		mov ecx, eax
		jmp deltes_end
		//Если дельты (-1,1) - лево-верх
	deltes_m1_1:
		mov ecx, [edi+16]	//действие из дельты -1,0
		mov eax, [edi+20]	//действие из 0,1
		cmp eax, ecx
		jnc deltes_end
		mov ecx, eax
		jmp deltes_end
		//Если дельты (-1,-1) - лево низ
	deltes_m1_m1:
		mov ecx, [edi+16]	//действие из дельты -1,0
		mov eax, Lenght2	//действие из 0, -1
		sub eax, [edi+20]
		dec eax
		cmp eax, ecx
		jnc deltes_end
		mov ecx, eax
		jmp deltes_end

	deltes_end:
		cmp ecx ,0
		jz get_line_end

		mov eax, [edi+20]
		mov edx, [edi+16]
	loop_deltes:
		sub eax, [edi+8]
		add edx, [edi+12]
		push eax
		push edx
		call chessboard_by_index
		mov [ebx], 1
		loop loop_deltes

	get_line_end:
		pop edx
		pop ecx
		pop ebx
		pop eax
		pop edi
		ret 16

	//set_queen_lines:	//void set_queen_lines(x, y) x- строка, y - столбец. Устанавливает линии, по которым бьет королева(включая ее)
	//	push edi
	//	mov edi, esp
	//	push esi
	//	push eax
	//	push ebx
	//	push ecx

	//	mov ecx, 1	//для горизонтально, вертикальной линий и отклонения по диагонали

	//cycle_queen_lines:
	//	mov eax, [edi + 12]
	//	add eax, ecx
	//	cmp eax, Lenght1
	//	jnc vert_down_end
	//	push eax	//????????????????????????????????????????
	//	push [edi+8]
	//	call chessboard_by_index
	//	mov [ebx], 1	//????????????????????
	//					//Получение диагоналей:
	//	mov esi, [edi+8]
	//	add esi, ecx
	//	cmp esi, Lenght1
	//	jnc diog_down_right_end
	//	push eax
	//	push esi
	//	call chessboard_by_index
	//	mov [ebx], 1

	//diog_down_right_end:
	//	mov esi, [edi+8]
	//	sub esi, ecx
	//	jc vert_down_end
	//	push eax
	//	push esi
	//	call chessboard_by_index
	//	mov [ebx], 1

	//vert_down_end:
	//	mov eax, [edi + 12]
	//	sub eax, ecx
	//	jc vert_up_end
	//	push eax	//????????????????????????????????????????
	//	push [edi+8]
	//	call chessboard_by_index
	//	mov [ebx], 1	//????????????????????
	//					//Получение диагоналей:
	//	mov esi, [edi+8]
	//	add esi, ecx
	//	cmp esi, Lenght1
	//	jnc diog_up_right_end
	//	push eax
	//	push esi
	//	call chessboard_by_index
	//	mov [ebx], 1

	//diog_up_right_end:
	//	mov esi, [edi+8]
	//	sub esi, ecx
	//	jc vert_up_end
	//	push eax
	//	push esi
	//	call chessboard_by_index
	//	mov [ebx], 1

	//vert_up_end:
	//	mov eax, [edi + 8]
	//	add eax, ecx
	//	cmp eax, Lenght1
	//	jnc hor_right_end
	//	push [edi+12]
	//	push eax
	//	call chessboard_by_index
	//	mov [ebx],1

	//hor_right_end:
	//	mov eax, [edi + 8]
	//	sub eax, ecx
	//	jc hor_left_end
	//	push [edi+12]
	//	push eax
	//	call chessboard_by_index
	//	mov [ebx],1

	//hor_left_end:
	//	inc ecx
	//	cmp ecx, Lenght2
	//	jnz cycle_queen_lines

	//	pop ecx
	//	pop ebx
	//	pop eax
	//	pop esi
	//	pop edi
	//	ret 8
	
	chessboard_by_index: 	//Записывает адрес элемента в ebx по индексу(x,y) из стека, где y - столбец
		push edi
		mov edi, esp
		push eax

		mov eax,[edi+12]
		shl eax, 3
		mov ebx, chessboard
		add ebx, eax
		add ebx, [edi+8]

		pop eax
		pop edi
		ret 8

	maxPositions_by_index:	//Записывает адрес элемента в ebx по индексу(x,y) из стека, где y - столбец
		push edi
		mov edi, esp
		push eax

		mov eax,[edi+12]
		shl eax, 3
		lea ebx, maxPositions
		add ebx, eax
		add ebx, [edi+8]

		pop eax
		pop edi
		ret 8


	end_pr:

	}

	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++)
			cout << (int)array[i][j] << " ";
		cout << endl;
	}
	cout << "Summa elementov: " << summArray << endl;
	cout << "Poz s naibolshim kolichestvom porazjaemix poley: "<<endl;
	for (int i = 0; i < amountMaxPoints; i++) {
		for (int j = 0; j < 2; j++)
			cout << (int)maxPositions[i][j]+1 << " ";
		cout << endl;
	}
	cout << "Max summ: " << maxSum;
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
