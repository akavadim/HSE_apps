import org.testng.Assert;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

public class AccountTests {

    @DataProvider
    public Object[][] WithdrawData(){
        Account account=new Account();
        Account blockedAccount = new Account();
        account.deposit(1000);

        blockedAccount.deposit(1000);
        blockedAccount.block();

        Object[][] res = new Object[][]{
                new Object[]{account, -1, 1000, false},
                new Object[]{account, 0, 1000, true},
                new Object[]{account, 999, 1 , true},
                new Object[]{account, 1001, -1000, true},
                new Object[]{account, 1, -1000,false},

                new Object[]{blockedAccount, 100, 1000, false}
        };
        return  res;
    }

    @Test(dataProvider = "WithdrawData")
    public void WithdrawTest(Account account, int withdraw, int expectedBalance, boolean expectedResult){
        boolean actualResult = account.withdraw(withdraw);
        int actualBalance = account.getBalance();

        boolean actual = actualResult==expectedResult && actualBalance==expectedBalance;
        Assert.assertTrue(actual, "Balance: "+actualBalance + " ExpectedBalance:" + expectedBalance +
                " Result: "+actualResult + " ExpectedResult: "+expectedResult);
    }

    @DataProvider
    public  Object[][] SetMaxCreditData(){
        Account account = new Account();
        Account blockedAccount = new Account();
        blockedAccount.block();

        Object[][] res = new Object[][]{
                {account, 100, 1000, false},
                {blockedAccount,1000000, 1000000, true},
                {blockedAccount,1000001, 1000000, false},
                {blockedAccount, 100, 100, true}
        };

        return res;
    }

    @Test(dataProvider = "SetMaxCreditData")
    public void SetMaxCreditTest(Account account, int maxCredit, int expectedMaxCredit, boolean expectedResult){
        boolean actualResult = account.setMaxCredit(maxCredit);
        int actualMaxCredit = account.getMaxCredit();

        boolean actual = actualResult == expectedResult && actualMaxCredit==expectedMaxCredit;

        Assert.assertTrue(actual, "MaxCredit: "+actualMaxCredit+" ExpectedMaxCredit: " + expectedMaxCredit
        + " Result: "+ actualResult + " ExpectedRedult: "+expectedResult);
    }

    @Test
    public  void UnblockTest_Success(){
        Account account = new Account();
        account.withdraw(1000);
        account.block();

        boolean actual=account.unblock();
        boolean expected = true;

        Assert.assertEquals(actual, expected);
    }

    @Test
    public  void UnblockTest_Fail(){
        Account account = new Account();
        account.withdraw(100);
        account.block();
        account.setMaxCredit(99);

        boolean actual=account.unblock();
        boolean expected = false;

        Assert.assertEquals(actual, expected);
    }

    @DataProvider
    public Object[][] DepositData(){
        Account account=new Account();
        Account blockedAccount = new Account();
        blockedAccount.block();

        return  new Object[][]{
                new Object[]{account, 500, 500, true},
                new Object[]{account, -1, 500, false},
                new Object[]{account, 1000001, 500, false},
                new Object[]{account, 999500, 1000000, true},
                new Object[]{account, 1, 1000000, false},
                new Object[]{blockedAccount, 500, 0, false}
        };
    }

    @Test(dataProvider = "DepositData")
    public  void DepositTest(Account account, int deposit, int expectedBalance, boolean expectedResult){
        boolean actualResult = account.deposit(deposit);
        int actualBalance = account.getBalance();

        boolean actual = actualResult == expectedResult && actualBalance==expectedBalance;

        Assert.assertTrue(actual, "Balance: "+actualBalance+" ExpectedBalance: " + expectedBalance
                + " Result: "+ actualResult + " ExpectedRedult: "+expectedResult);
    }

    @Test
    public void BlockTest(){
        Account account=new Account();
        account.block();

        boolean actual = account.isBlocked();
        boolean expected = true;
        Assert.assertEquals(actual, expected);
    }
}
