public class Task5 : IAct, IShowCase, IShowResult
{
    string[] testArr;
    private int testCase;
    private string result;

    public Task5()
    {
        testArr = new string[] { "a",
                                 "ab",
                                 "bb",
                                 "bba",
                                 "abb",
                                 "ccc",             // 3c
                                 "123ccccLok",      // 4c
                                 "123cccccLok",     // 5c
                                 "12ccccccccSFx",   // 8c
                                 "12345abcd",
                                 "12cabdbac78jkaba",
                                 "13abcddcba7aba",
                                 "12zabcffcbaz96abba",
                                 "123cccabdfdbaccc78aba"};
    }

    public string LongestPalindrome(string s)
    {
        // Single symbol string
        if (s.Length == 1)
            return s;

        // Two symbol string
        if(s.Length == 2)
        {
            if (s[0] == s[1])
                return s;
            else
                return s.Substring(1, 1);
        }

        // Multy symbol string
        int curPos = 1;
        string result = s.Substring(0, 1);

        while(curPos + 1 <= s.Length)
        {
            // Odd case
            if(s[curPos - 1] == s[curPos])
            {
                string locResult = ScanPalindrom(curPos - 1, curPos, ref s);
                result = NewBiggerPalindrom(ref locResult, ref result);
            }

            if ((curPos + 1) == s.Length)
                break;

            // Even case
            if (s[curPos - 1] == s[curPos + 1])
            {
                string locResult = ScanPalindrom(curPos, curPos, ref s);
                result = NewBiggerPalindrom(ref locResult, ref result);
            }

            curPos++;
        }

        return result.ToLower();
    }

    private string ScanPalindrom(int firstPos, int secPos, ref string s)
    {
        while (s[firstPos] == s[secPos])
        {
            if ((firstPos > 0) &&
                (secPos < s.Length - 1))
            {
                firstPos--;
                secPos++;
            }
            else
            {
                firstPos--;
                secPos++;
                break;
            }
        }

        firstPos++;
        secPos--;

        string locResult = s.Substring(firstPos, ((secPos + 1) - firstPos));
        return locResult;
    }

    private string NewBiggerPalindrom(ref string locResult, ref string result)
    {
        if (locResult.Length > result.Length)
            result = locResult;

        return result;
    }

    public void Act()
    {
        try
        {
            result = LongestPalindrome(testArr[testCase]);
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