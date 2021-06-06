import java.lang.reflect.Array;
import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.List;

import org.testng.annotations.DataProvider;
import org.testng.collections.Lists;
import sun.security.util.ArrayUtil;

public class AdvSqrtTestDataProvider {

    @DataProvider
    public Object[][] NormalizedValues(){

        Object[][] values = new Object[][]{
           {123.123, Math.sqrt(123.123)}, //1.	Результат вычисления функции double sqrt (double x) в обычной ситуации должен быть точным математическим результатом
           {0.5, Math.sqrt(0.5)},
           {1233423.0, Math.sqrt(1233423.0)},
           {Double.longBitsToDouble(0x0010000000000001L) , Math.sqrt(Double.longBitsToDouble(0x0010000000000001L))}, //минимальное положительное значение (нормализованное)
           {Double.longBitsToDouble(0x0010000000000002L) , Math.sqrt(Double.longBitsToDouble(0x0010000000000002L))},
           {Double.longBitsToDouble(0x0010000000000003L) , Math.sqrt(Double.longBitsToDouble(0x0010000000000003L))},
           {Double.longBitsToDouble(0x7fefffffffffffffL) , Math.sqrt(Double.longBitsToDouble(0x7fefffffffffffffL))}, //максимальное положительное значение (нормализованное)


           {-4.001, Double.NaN},   //2.	Результатом вычисления sqrt с отрицательным аргументом (конечным) должно быть NaN
           {-20.0, Double.NaN},
           {Double.longBitsToDouble(0x8010000000000001L) , Double.NaN}, //минимальное отрицательное значение (нормализованное)
           {Double.longBitsToDouble(0xffefffffffffffffL) , Double.NaN}, //максимальное отрицательное значение (нормализованное)

           //Нулевые
           {0.0, 0.0}
        };

        return  values;
    }

    @DataProvider
    public Object[][] DenormalizedValues(){
        return new Object[][]{
            {Double.longBitsToDouble(0x0000000000000001L) , Math.sqrt(Double.longBitsToDouble(0x0000000000000001L))}, //минимальное положительное
            {Double.longBitsToDouble(0x000fffffffffffffL) , Math.sqrt(Double.longBitsToDouble(0x000fffffffffffffL))}, //максимадльное положительное
            {Double.longBitsToDouble(0x0001234567890122L) , Math.sqrt(Double.longBitsToDouble(0x0001234567890123L))},
            
            {Double.longBitsToDouble(0x8000000000000001L) , Double.NaN}, //минимальное отрицательное значение
            {Double.longBitsToDouble(0x800fffffffffffffL) , Double.NaN}, //максимальное отрицательное отрицательное значение
            {Double.longBitsToDouble(0x8001234567890122L) , Double.NaN}
        };
    }

    @DataProvider
    public Object[][] ZeroesValues(){
        return new Object[][]{
            {Double.longBitsToDouble(0x0000000000000000L) , Double.longBitsToDouble(0x0000000000000000L)}, //+ 0
            {Double.longBitsToDouble(0x8000000000000000L) , Double.longBitsToDouble(0x8000000000000000L)} //- 0
        };
    }

    @DataProvider
    public Object[][] InfinityValues(){
        return new Object[][]{
            {Double.longBitsToDouble(0x7ff0000000000000L) , Double.longBitsToDouble(0x7ff0000000000000L)}, //+ бесконечность
            {Double.longBitsToDouble(0xfff0000000000000L) , Double.NaN} //- бесконечность
        };
    }

    @DataProvider
    public Object[][] NanValues(){
        return new Object[][]{
            {Double.longBitsToDouble(0x7ff0000000000001L) , Double.NaN}, //+ При m!=0, x=nan
            {Double.longBitsToDouble(0x7fffffffffffffffL) , Double.NaN},
            {Double.longBitsToDouble(0x7ff0123456789102L) , Double.NaN},

            {Double.longBitsToDouble(0xfff0000000000001L) , Double.NaN},
            {Double.longBitsToDouble(0xffffffffffffffffL) , Double.NaN},
            {Double.longBitsToDouble(0xfff0123456789102L) , Double.NaN}
        };
    }
}
