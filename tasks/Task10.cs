public class Task10 : IAct, IShowCase, IShowResult
{
    private readonly string[] testArr;
    private readonly string[] testArr2;
    private int testCase;
    private bool result;

    public Task10()
    {
        testArr = new string[] { "aa",
                                 "aab",
                                 "askdj",
                                 "askdj",
                                 "akjsf",
                                 "askll",
                                 "askll",
                                 "askll",
                                 "aknbhg",
                                 "aknbhg",
                                 "aknbhg",
                                 "aknbhg",
                                 "m3xceu",
                                 "m3xceu",
                                 "m3xceu",
                                 "m3xceu",
                                 "m3xceu",
                                 "m3xceu" };

        testArr2 = new string[] { "a",
                                  "c*a*b",
                                  "askdj",
                                  "askdi",
                                  "aa",
                                  "ask..",
                                  ".skl.",
                                  "..kll",
                                  "ak*g",
                                  "*ak....",
                                  "ak*",
                                  "*ak*",
                                  ".3*",
                                  ".3xc...*",
                                  ".3xc.b",
                                  ".3xc..b*",
                                  ".3xc..bca*",
                                  ".*3*e." };
        testCase = 0;
        result = false;
    }

    private bool IsMatch(string s, string p)
    {
        int curPos = -1;
        for (int i = 0; i < s.Length; i++)
        {
            if (curPos < p.Length - 1)
                curPos++;
            else
                return false;
            if (p[curPos] == '.')
                continue;
            if (p[curPos] == '*')
            {
                if (curPos < p.Length - 1)
                    curPos++;
                else
                    return true;

                bool locMatch = false;
                for(int n = i; n < s.Length; n++)
                {
                    if (s[n] != p[curPos])
                        continue;
                    else
                    {
                        locMatch = true;
                        i = n;
                        break;
                    }
                }
                if (!locMatch)
                    return false;
                continue;
            }
            if (s[i] != p[curPos])
                return false;
        }
        if (curPos < p.Length - 1)
        {
            curPos++;
            if (p[curPos] != '*')
                return false;
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