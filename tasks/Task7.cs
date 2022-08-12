public class Task7 : IAct, IShowCase, IShowResult
{
    private readonly int[] testArr;
    private int testCase;
    private int result;

    public Task7()
    {
        testArr = new int[] { 1534236469, -123, 123, 444, 120, -123 };
        testCase = 0;
        result = 0;
    }

    private int Reverse(int x)
    {
        bool negative = false;

        if(x < 0)
        {
            x *= -1;
            negative = true;
        }

        string number = x.ToString();
        string buffer = "";
        int result = 0;
        
        for(int i = number.Length - 1; i >= 0; i--)
        {
            buffer += number[i];
        }

        try
        {
            result = Convert.ToInt32(buffer);
        }
        catch
        {
            result = 0;
        }

        if (negative)
            result *= -1;

        return result;
    }

    public void Act()
    {
        try
        {
            result = Reverse(testArr[testCase]);
        }
        catch
        {
            OutputHelper.Show($" test case: {testCase} testData: {testArr[testCase]}");
            OutputHelper.Show(" ERROR!!! ");
            //throw new Exception();
        }
    }
    
    public bool IsNext()
    {
        if(testCase < testArr.Length - 1)
        {
            testCase++;
            return true;
        }
        return false;
    }

    public void ShowCase()
    {
        OutputHelper.Show($" test #: {testCase} case: {testArr[testCase]}");
    }

    public void ShowResult()
    {
        OutputHelper.Show($"    result: {result}");
    }
}