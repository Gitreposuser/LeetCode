public class Task8 : IAct, IShowCase, IShowResult
{
    private string[] testArr;
    private int testCase;
    private int result;

    public Task8()
    {
        testArr = new string[] { "",
                                 "-",
                                 "+",
                                 "  + 43",
                                 "+1",      // 1
                                 "+-12",    // 0
                                 "+123",
                                 "+123+",
                                 "123",
                                 "-123", 
                                 "123-",
                                 "-123-",
                                 " 124abc5",
                                 "   +0 123",
                                 "   -12zb56c7 8",
                                 "9837468747873652",
                                 "-498562763523762376",
                                 "a1",      // 0
                                 "1a",      // 1
                                 "a1a" };   // 0

        testCase = 0;
        result = 0;
    }

    private int MyAtoi(string s)
    {
        string buffer = "";
        bool isNegative = false;

        bool signePhase = false;
        bool numberPhase = false;

        for(int curPos = 0; curPos < s.Length; curPos++)
        {
            switch (s[curPos])
            {
                case ' ':
                    if(signePhase || numberPhase)
                        curPos = s.Length;
                    break;
                case '+':
                    if(signePhase || numberPhase)
                    {
                        curPos = s.Length;
                        break;
                    }
                    signePhase = true;
                    break;
                case '-':
                    if(signePhase || numberPhase)
                    {
                        curPos = s.Length;
                        break;
                    }
                    signePhase = true;
                    isNegative = true;
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    numberPhase = true;
                    buffer += s[curPos];
                    break;
                default:
                    curPos = s.Length;
                    break;
            }
        }

        if (buffer == "")
            return 0;

        int result = 0;
        try
        {
            result = Int32.Parse(buffer);
        }
        catch
        {
            if (isNegative)
                result = int.MinValue;
            else
                result = int.MaxValue;
        }

        if (isNegative)
            result *= -1;

        return result;
    }

    public void Act()
    {
        try
        {
            result = MyAtoi(testArr[testCase]);
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