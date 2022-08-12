public class Task9 : IAct, IShowCase, IShowResult
{
    private int[] testArr;
    private int testCase;
    private bool result;

    public Task9()
    {
        testArr = new int[] { 1,
                              12,
                              121,
                              1221,
                              21,
                              353,
                              3553,
                              35753 };
        testCase = 0;
        result = false;
    }

    private bool IsPalindrome(int x)
    {
        string buffer = x.ToString();
        int firstPos = 0;
        int secPos = buffer.Length - 1;

        while(firstPos < secPos)
        {
            if (buffer[firstPos] != buffer[secPos])
                return false;
            firstPos++;
            secPos--;
        }
        return true;
    }

    public void Act()
    {
        try
        {
            result = IsPalindrome(testArr[testCase]);
        }
        catch
        {
            OutputHelper.Show($" test case: {testCase} testData: {testArr[testCase]}");
            OutputHelper.Show(" ERROR!!! ");
        }
    }

    public bool IsNext()
    {
        if (testCase < testArr.Length - 1)
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