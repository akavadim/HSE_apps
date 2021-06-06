package Tests;

import static org.junit.jupiter.api.Assertions.assertEquals;
import org.junit.jupiter.api.Test;
import Gcd.GCD;

public class GcdTests {
    private final GCD gcd=new GCD();

//#region Отрицательные и положительные числа

    @Test
    void gcdTest_positive_positive(){
        var number1=10;
        var number2=15;
        
        var actual = gcd.gcd(number1, number2);
        
        assertEquals(5, actual);
    }
    
    @Test
    void gcdTest_negative_positive(){
        var number1=-10;
        var number2=15;
        
        var actual = gcd.gcd(number1, number2);
        
        assertEquals(5, actual);
    }

    @Test
    void gcdTest_positive_negative(){
        var number1=10;
        var number2=-15;
        
        var actual = gcd.gcd(number1, number2);
        
        assertEquals(5, actual);
    }

    @Test
    void gcdTest_negative_negative(){
        var number1=-10;
        var number2=-15;
        
        var actual = gcd.gcd(number1, number2);
        
        assertEquals(5, actual);
    }

//#endregion 

//#region нулевые значения

    @Test
    void gcdTest_zero_positive(){
        var number1=0;
        var number2=15;
        
        var actual = gcd.gcd(number1, number2);
        
        assertEquals(15, actual);
    }

    @Test
    void gcdTest_positive_zero(){
        var number1=20;
        var number2=0;
        
        var actual = gcd.gcd(number1, number2);
        
        assertEquals(20, actual);
    }

    @Test
    void gcdTest_zero_zero(){
        var number1=0;
        var number2=0;
        
        var actual = gcd.gcd(number1, number2);
        
        assertEquals(0, actual);
    }

//#endregion

//#region Неединичные взаимно простые аргументы (наибольший общий делитель равен единице)

@Test
void gcdTest_res_1(){
    var number1=59;
    var number2=1231;
    
    var actual = gcd.gcd(number1, number2);
    
    assertEquals(1, actual);
}

//#endregion

//#region равные значения

@Test
void gcdTest_equal(){
    var number1=-9999;
    var number2=-9999;
    
    var actual = gcd.gcd(number1, number2);
    
    assertEquals(9999, actual);
}

//#endregion

//#region Неравные значения аргументов, при которых первый делит второй, 
//второй делит первый (результат должен совпадать с меньшим аргументом по абсолютной величине)

@Test
void gcdTest_nuber1_half_of_number2(){
    var number1=2501;
    var number2=5002;
    
    var actual = gcd.gcd(number1, number2);
    
    assertEquals(2501, actual);
}

@Test
void gcdTest_nuber2_half_of_number1(){
    var number1=-5004;
    var number2=-2502;
    
    var actual = gcd.gcd(number1, number2);
    
    assertEquals(2502, actual);
}
//#endregion

//#region Неравные значения аргументов, дающие неединичный наибольший общий делитель

@Test
void gcdTest_not_equal(){
    var number1=-812928;
    var number2=308352;
    
    var actual = gcd.gcd(number1, number2);
    
    assertEquals(28032, actual);
}


//#endregion

//#region Граничные значения аргументов 

@Test
void gcdTest_max_max(){
    var number1=Integer.MAX_VALUE;
    var number2=Integer.MAX_VALUE;
    
    var actual = gcd.gcd(number1, number2);
    
    assertEquals(Integer.MAX_VALUE, actual);
}

@Test
void gcdTest_max_min(){
    var number1=Integer.MAX_VALUE;
    var number2=Integer.MIN_VALUE+1;
    
    var actual = gcd.gcd(number1, number2);
    
    assertEquals(Integer.MAX_VALUE, actual);
}


@Test
void gcdTest_min_min(){
    var number1=Integer.MIN_VALUE;
    var number2=Integer.MIN_VALUE;
    
    var actual = gcd.gcd(number1, number2);
    
    assertEquals(-Integer.MIN_VALUE, actual);
}

//#endregion
}
