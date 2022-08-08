public class Task5
{
    public Task5()
    {
        string[] testArr = { "a",
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

        TestAllCases(testArr);
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

    private void TestAllCases(string[] testArr)
    {
        int testCase = 0;
        try
        {
            for(; testCase < testArr.Length; testCase++)
            {
                Show($"test case: {testArr[testCase]} result: {LongestPalindrome(testArr[testCase])}");
            }
            Show(" ******* \n >>> All test successful <<< \n *******");
        }
        catch
        {
            Show($"case: {testCase} with string: {testArr[testCase]} - Failed!");
        }
    }

    private void Show(string message)
    {
#if DEBUG
        Debug.WriteLine(message);
#else
        Console.WriteLine(message);
#endif
    }
}