Run("calc.exe")
WinWaitActive("Калькулятор")
AutoItSetOption("SendKeyDelay", 50)

TestInt()
TestFloat()
TestPercentage()
TestMemory()
TestBackspace()
TestChangingSign()

MsgBox(0, "Тест завершен", "Тест завершен")

Exit

Func TestBigNumbers()
   Send("{ESC}")
   Send("12345678901234567,890123456789012")
   Send("{-}")
   Send("-2345678901234567,890123456789012")
   Send("{ENTER}")
   AssertEquils(GetResult(), 10000000000000000, "Работа с большими цифрами некорректна (33 символа)")
EndFunc

#Region Int

Func TestInt()
   TestIntAddition()
   TestIntSubstraction()
   TestIntMultiplication()
   TestIntDivision()
EndFunc

Func TestIntAddition()
   Send("{ESC}")
   Send("12345")
   Send("{+}")
   Send("6789")
   Send("{ENTER}")
   AssertEquils(GetResult(), 19134, "Сложение целых чисел некорректно")
EndFunc

Func TestIntSubstraction()
   Send("{ESC}")
   Send("11")
   Send("{-}")
   Send("100")
   Send("{ENTER}")
   AssertEquils(GetResult(), -89, "Вычитание целых чисел некорректно")
EndFunc

Func TestIntMultiplication()
   Send("{ESC}")
   Send("33")
   Send("{*}")
   Send("2")
   Send("{ENTER}")
   AssertEquils(GetResult(), 66, "Умножение целых чисел некорректно")
EndFunc

Func TestIntDivision()
   Send("{ESC}")
   Send("-350")
   Send("{/}")
   Send("50")
   Send("{ENTER}")
   AssertEquils(GetResult(), -7, "Деление целых чисел некорректно")
EndFunc

#EndRegion

#Region Float

Func TestFloat()
   TestFloatAddition()
   TestFloatSubstraction()
   TestFloatMultiplication()
   TestFloatDivision()
   TestInversionNumber()
   TestSqrt()
EndFunc

Func TestFloatAddition()
   Send("{ESC}")
   Send("12345,12345")
   Send("{+}")
   Send("6789,1")
   Send("{ENTER}")
   AssertEquils(GetResult(), 19134.22345, "Сложение чисел с плавающей точкой некорректно")
EndFunc

Func TestFloatSubstraction()
   Send("{ESC}")
   Send("11,1")
   Send("{-}")
   Send("100,5")
   Send("{ENTER}")
   AssertEquils(GetResult(), -89.4, "Вычитание чисел с плавающей точкой некорректно")
EndFunc

Func TestFloatMultiplication()
   Send("{ESC}")
   Send("33,33")
   Send("{*}")
   Send("2,5")
   Send("{ENTER}")
   AssertEquils(GetResult(), 83.325, "Умножение чисел с плавающей точкой некорректно")
EndFunc

Func TestFloatDivision()
   Send("{ESC}")
   Send("-35,56")
   Send("/")
   Send("100")
   Send("{ENTER}")
   AssertEquils(GetResult(), -0.3556, "Деление чисел с плавающей точкой некорректно")
EndFunc

Func TestInversionNumber()
   Send("{ESC}")
   Send("100")
   Send("r")
   AssertEquils(GetResult(), 0.01, "Некорректное обратное число")
EndFunc

Func TestSqrt()
   Send("{ESC}")
   Send("100")
   Send("@")
   AssertEquils(GetResult(), 10, "Получен некорректный корень")
EndFunc

#EndRegion

#Region Percentage

Func TestPercentage()
   TestPercentageMultiply()
   TestPercentageAdditional()
   TestPercentageSubstraction()
EndFunc

Func TestPercentageMultiply()
   Send("{ESC}")
   Send("100")
   Send("{*}")
   Send("21")
   Send("%")
   Send("{ENTER}")
   AssertEquils(GetResult(), 21, "Получение процентов некорректно")
EndFunc

Func TestPercentageAdditional()
   Send("{ESC}")
   Send("100")
   Send("{+}")
   Send("50")
   Send("%")
   Send("{ENTER}")
   AssertEquils(GetResult(), 150, "Сумма числа и процентов от него некорректно")
EndFunc

Func TestPercentageSubstraction()
   Send("{ESC}")
   Send("100")
   Send("{-}")
   Send("63")
   Send("%")
   Send("{ENTER}")
   AssertEquils(GetResult(), 37, "Отнитие от числа его процентов некорретно")
EndFunc

#EndRegion

Func TestMemory()
   Send("{ESC}")
   Send("100")
   Send("{CTRLDOWN}m{CTRLUP}")
   Send("{ESC}")
   Send("{CTRLDOWN}r{CTRLUP}")
   AssertEquils(GetResult(), 100, "Число не запомнено в ячейке памяти")

   Send("{ESC}")
   Send("30")
   Send("{CTRLDOWN}p{CTRLUP}")
   Send("{CTRLDOWN}r{CTRLUP}")
   AssertEquils(GetResult(), 130, "Число не сложено в ячейке памяти")

   Send("{ESC}")
   Send("{CTRLDOWN}l{CTRLUP}")
   Send("30")
   Send("{ESC}")
   Send("{CTRLDOWN}r{CTRLUP}")
    AssertEquils(GetResult(), 0, "Число не стерто в ячейке памяти")

EndFunc

Func TestBackspace()
   Send("{ESC}")
   Send("100")
   Send("{BACKSPACE}")
   AssertEquils(GetResult(), 10, "Backspace не работает")
EndFunc

Func TestChangingSign()
   Send("{ESC}")
   Send("100")
   Send("{F9}")
   AssertEquils(GetResult(), -100, "Смена знака с плюса на минус не работает")
   Send("{F9}")
   AssertEquils(GetResult(), 100, "Смена знака с минуса на плюс не работает")
EndFunc

Func GetResult()
	Send("{CTRLDOWN}c{CTRLUP}")
	$str = StringReplace(ClipGet(), ",", ".")
	return Number($str)
EndFunc

Func AssertEquils($Actual, $Expected, $Message)
   if Not ($Actual = $Expected) Then
	  MsgBox(0, "Тест не прошел", $Message & @LF & $Actual & " Получено, но ожидалось " & $Expected)
	  EndIf
EndFunc
