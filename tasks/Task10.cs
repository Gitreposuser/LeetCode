public class Task10 : IAct, IShowCase, IShowResult
{
    private readonly string[] testArr;
    private readonly string[] testArr2;
    private int testCase;
    private bool result;

    public Task10()
    {
        testArr = new string[] { "aa",
                                 "a",
                                 "aaa",
                                 "aaa",
                                 "aab",
                                 "baa",
                                 "baa",
                                 "baa",
                                 "bab",
                                 "baa",
                                 "baa",
                                 "baa",
                                 "baa",
                                 "baa",
                                 "baa",
                                 "a" };

        testArr2 = new string[] { "a",
                                  "aa",
                                  "a*a",
                                  "a*b",
                                  "a*.",
                                  "a*.",
                                  "a*aa",
                                  "a*baa",
                                  "a*.aa",
                                  "a*b*ab",
                                  ".*",
                                  ".*c",
                                  ".*a",
                                  ".*.",
                                  ".*....",
                                  "a"};
        testCase = 0;
        result = false;
    }

    private bool IsMatch(string s, string p)
    {
        int sPos = -1;
        int pPos = -1;
        bool sEnd = false;
        bool pEnd = false;
        char prev = s[0];

        while(true)
        {
            // Increasing phrase and filter positions
            if (sPos < s.Length - 1)
                sPos++;
            else
                sEnd = true;
            if (pPos < p.Length - 1)
                pPos++;
            else
                pEnd = true;

            if (sEnd && pEnd)
                break;

            if ('*' == p[pPos])
            {
                int i = sPos;
                for(; i < s.Length; i++)
                {
                    if ('.' == prev)
                        continue;
                    if (prev == s[i])
                        continue;
                    else
                    {
                        sPos = i;
                        break;
                    }
                }
                sPos = i - 1;
                continue;
            }
            // Simple cases '.' and symbol
            if ('.' == p[pPos])
            {
                prev = '.';
                continue;
            }
            if (s[sPos] == p[pPos] && (!pEnd))
            {
                prev = s[sPos];
            }
            else
            {
                if (pPos < p.Length - 1)
                {
                    if ('*' == p[pPos + 1])
                    {
                        sPos--;
                        pPos++;
                        continue;
                    }
                }
                return false;
            }
        }
        return true;
    }

    public void Act()
    {
        try
        {
            result = IsMatch(testArr[testCase], testArr2[testCase]);
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
        OutputHelper.Show($" test #: {testCase} case: {testArr[testCase]}" +
                          $" - {testArr2[testCase]}");
    }

    public void ShowResult()
    {
        OutputHelper.Show($"    result: {result}");
    }
}
