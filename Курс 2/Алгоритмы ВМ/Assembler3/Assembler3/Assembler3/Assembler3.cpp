// Assembler3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#define _USE_MATH_DEFINES // for C++
#include <math.h>

int main()
{
	int16_t n = 0,
		counter = 20,
		forCWR;
	double toch = 0.001,
		x = 3,
		Pi=M_PI,
		resN,
		resToch,
		resOrig,
		check;
	bool error = false;

	__asm {
	res_by_n:
		fstcw forCWR
		btr forCWR, 2
		fldcw forCWR

		fld x
		fldz	//res st 0
		mov cx, n
	loop_res_by_n:
		
		push cx
		fild word ptr[esp]	
		pop cx
		fldz  //временный результат, x
		fadd st(0), st(3)
		//x st(3) res st2, cx st1, x st0
		fmul st(0), st(1)	//x*i	st(0)
		fcos	//cos(x*i) st(0)
		fdiv st(0), st(1) //cos(x*i)/i st(0)
		fstsw ax
		bt ax, 2
		jc pr_zero_error
		fdiv st(0), st(1) //cos(x*i)/(i*i) st(0)
		bt cx, 0
		jnc res_by_n_chetnoe
		fchs 
	res_by_n_chetnoe:
		fadd st(2), st(0)	//res=res+временный рез.
		fstp st(0)
		fstp st(0)	//удаление из стека временного результата и cx

		loop loop_res_by_n
		fstp resN //стек пуст

	res_by_toch:
		mov ax, counter
		fld toch	//st 1
		fldz //res st0
		mov cx, 1

	loop_res_by_toch:
		
		push cx
		fild word ptr[esp]
		pop cx
		fldz  //временный результат, x
		fadd st(0), st(4)
		//x st4 toch st3, res st2, cx st1, x st0
		fmul st(0), st(1)	//x*i	st(0)
		fcos	//cos(x*i) st(0)
		fdiv st(0), st(1) //cos(x*i)/i st(0)
		fdiv st(0), st(1) //cos(x*i)/(i*i) st(0)
		bt cx, 0
		jnc res_by_toch_chetnoe
		fchs
	res_by_toch_chetnoe:
		fadd st(2), st(0)	//res=res+временный рез.
		fxch st(1)
		fstp st(0)	//удаление из стека cx
		//toch st2, res st1, временный рез. st0
		inc cx
		fabs 
		fcomip st(0), st(2)
		ja loop_res_by_toch //(временный рез.)>toch
		//counter st2 toch st1, res st0
		dec ax
		cmp ax, 0
		jne loop_res_by_toch
		fstp resToch
		fstp st(0)

	res_original:
		fld x
		fld x
		fmulp st(1), st(0)
		//st0 =x*x
		fld Pi
		fld Pi
		fmulp st(1), st(0)
		//st0=pi*pi, st1=x*x
		mov cx, 3
		push cx
		fild word ptr[esp]
		pop cx
		fdivp st(1), st(0)
		//st0=pi*pi/3, st1=x*x
		fsubp st(1), st(0)
		//st0=x*x-pi*pi/3
		mov cx, 4
		push cx
		fild word ptr[esp]
		pop cx
		fdivp st(1), st(0)
		fstp resOrig
		jmp pr_end

		pr_zero_error:
		mov error, 1

		pr_end:
	}

	if (error)
		std::cout << "Error. Divide by Zero.";
	else
		std::cout <<"SN: "<< resN << "\nSE: " << resToch<<"\nY : "<<resOrig;
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

	//start_programm:
	//	fld b
	//	fld x
	//	fsubp st(1), st(0)
	//	mov eax, 10
	//	push eax
	//	fild dword ptr[esp]
	//	pop eax
	//	fdivp st(1), st(0)
	//	

	//		
	//	fst sh	//в sh шаг
	//	fld b
	//	fld x

	//cycle_x_se_b:

	//	fldz
	//	mov ecx, 1
	//cycle_c_se_n:	//c <= n
	//	pop ecx
	//	pop x
	//	call get_function1
	//	fld res_function1	//st(0)		sn st(1) 
	//	faddp st(1), st(0)

	//	inc ecx
	//	cmp ecx, n
	//	jbe cycle_c_se_n
	//	fstp sn //результат в sn

	//	fld toch
	//	fldz
	//	mov ecx, 1
	//cycle_z_toch:

	//	pop ecx
	//	pop x
	//	call get_function1
	//	fld res_function1	//st(0)		se st(1)  //toch st(2)
	//	fadd st(1), st(0)
	//	inc ecx
	//	fcomip st(0), st(2)	
	//	ja cycle_z_toch
	//	fstp se


	//	fadd st(0), st(2)	//x=x+sh
	//	fcomi st(0), st(1)	
	//	jbe cycle_x_se_b
	//	fstp x

	//get_function1:	//(-1)^c*cos(c*x)/(c*c)  //res_function1 get_function1(int c, double x)
	//	push edi
	//	mov edi, esp
	//	push ecx

	//	fild dbword ptr[edi + 16]	//st 1 
	//	fld qword ptr[edi+12]	//st 0
	//	fmulp st(1), st(0) //(c*x) st 0
	//	fcos	//cos(c*x) st 0
	//	fild dword ptr[edi+16]	//st 0  //cos(c*x) st 1
	//	fdiv st(1), st(0) //c st 0, cos(c*x)/c st 1
	//	fdivp st(1), st(0)	//cos(c*x)/(c*c) st(0)
	//	fstp res_function1

	//	mov ecx, [edi+16]	//c	
	//	bt ecx, 0
	//	jnc chetnoe
	//	bts res_function1, 63

	//chetnoe:
	//	pop ecx
	//	pop edi
	//	ret 12

	//get_functionY:	//(1/4)*((x*x)-((PI*PI)/3)), res_functionY get_functionY(double x)
	//	push edi
	//	mov edi, esp
	//	push ecx

	//	fld1
	//	mov ecx, 4
	//	push ecx
	//	fild dword ptr[esp]
	//	pop ecx	//1 st(1), 4 st(0)
	//	fdivp st(1), st(0)	//1/4 st(0)
	//	fld 

	//end_programm: