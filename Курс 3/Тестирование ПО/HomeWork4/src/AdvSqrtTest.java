import java.util.Random;

import org.testng.Assert;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

public class AdvSqrtTest {
    Random random;

    @BeforeClass
    public void Initialization(){
        random=new Random();
    }

    @Test(dataProvider = "NormalizedValues")
    public  void NormalizedValuesTest(final double value, final double expected)
    {
        double actual = AdvSqrt.sqrt(value);
        Assert.assertEquals(actual, expected);
    }

    @Test(dataProvider = "SmallNormalizedValues")
    public  void SmallNormalizedValuesTest(final double value, final double expected)
    {
        double actual = AdvSqrt.sqrt(value);
        Assert.assertEquals(actual, expected);
    }

    @Test(dataProvider = "DenormalizedValues")
    public  void DenormalizedValuesTest(final double value, final double expected)
    {
        double actual = AdvSqrt.sqrt(value);
        Assert.assertEquals(actual, expected);
    }

    @Test(dataProvider = "ZeroesValues")
    public  void ZeroesValuesTest(final double value, final double expected)
    {
        double actual = AdvSqrt.sqrt(value);
        Assert.assertEquals(actual, expected);
    }

    @Test(dataProvider = "InfinityValues")
    public  void InfinityValuesTest(final double value, final double expected)
    {
        double actual = AdvSqrt.sqrt(value);
        Assert.assertEquals(actual, expected);
    }

    @Test(dataProvider = "NanValues")
    public  void NanValuesTest(final double value, final double expected)
    {
        double actual = AdvSqrt.sqrt(value);
        Assert.assertEquals(actual, expected);
    }

    @Test( dataProvider = "NormalizedValues", dataProviderClass = AdvSqrtTestDataProvider.class)
    public void SqrtTest_Property1(double value, double expected){
        if(value>=0){
           double rand= random.nextDouble();
           double val1 = AdvSqrt.sqrt(value);
           double val2 = AdvSqrt.sqrt(rand);
           double act = AdvSqrt.sqrt(value*rand);
           double exp = val1*val2;
           Assert.assertEquals(act, exp);
        }
        else{
            double actual = AdvSqrt.sqrt(value);
            Assert.assertEquals(actual, expected);
        }
    }
}
