import static jdk.nashorn.internal.objects.Global.Infinity;

public class AdvSqrt
{
    private static double eps = 2.25e-16;
    private static long   dgmask  = 0x7FF0000000000000L;
    private static long   mtmask  = 0x000FFFFFFFFFFFFFL;
    private static int    dgshift = 52;
    private static int    sqdgadd = 0x1FF;
    private static double dnrbnd  = Double.longBitsToDouble(0x0010000000000000L);
    private static long   odddeg  = 0x3FF0000000000000L;
    private static long   evndeg  = 0x3FE0000000000000L;

    public static double sqrt(double x)
    {
        //Результатом вычисления sqrt с отрицательным аргументом (конечным или бесконечным, но не -0) должно быть NaN.
        //Результатом вычисления sqrt с аргументом NaN должно быть NaN.
        if(Double.isNaN(x) || x < 0 || x==Double.NEGATIVE_INFINITY) return Double.NaN;
        //Результатом вычисления sqrt с аргументом +беск. должна быть +беск.
        else if(x == 0 || x == 1 || Double.isInfinite(x)) return x;
        //Результат вычисления функции double sqrt (double x) в обычной ситуации
        else
        {
            boolean dnr = false;
            //не покрыто
            if(x < dnrbnd)
            {
                x = x*Math.pow(2, dgshift);
                dnr = true;
            }
            long b = Double.doubleToLongBits(x);
            int d = (int)((b & dgmask) >> dgshift);
            double res, tmp;
            int i = 0;

            if((d & 1) != 0)
                b = (b & mtmask) | odddeg;
            else
                b = (b & mtmask) | evndeg;

            x = Double.longBitsToDouble(b);
            res = x;

            while(Math.abs(x-res*res)/x > eps )
            {
                i++;
                tmp = res;
                res = (tmp + x/tmp)/2;
            }

            b = Double.doubleToLongBits(res);
            //Корректно округленным к ближайшему
            d = (int)Math.round((double)d/2)+sqdgadd;
            if(dnr) d -= dgshift/2;

            b = (b & mtmask) | ((long)d << dgshift);
            res = Double.longBitsToDouble(b);
            return res;
        }
    }

}


