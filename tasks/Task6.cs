public class Task6 : IAct, IShowCase, IShowResult
{
    private readonly string[] testArr;
    private readonly int[] testRows;
    private int testCase;
    private string result;

    public Task6()
    {
        testArr = new string[] { "PAYPALISHIRING",
                                 "aaabbbcccdddeee",
                                 "A",
                                 "bb",
                                 "bba",
                                 "abb",
                                 "ccc"};
        testRows = new int[] { 4,
                               2,
                               3,
                               4,
                               5,
                               6,
                               7 };
    }

    public string Convert(string s, int numRows)
    {
        if (s.Length < 2)
            return s;

        List<string>[] resArray = new List<string>[numRows];

        // Init lists
        for (int i = 0; i < numRows; i++)
        {
            resArray[i] = new List<string>();
            resArray[i].Add("");
        }

        int pendulum = 0;
        int direction = 1;

        for(int i = 0; i < s.Length; i++)
        {
            // Adding to every array with calculated index
            resArray[pendulum][0] += (s[i].ToString());

            // Pendulum swings from 0 to numRows and back
            pendulum += direction;
            if (pendulum < 0)
            {
                direction = 1;
                pendulum = 1;
            }
            if (pendulum >= numRows - 1)
            {
                direction = -1;
                pendulum = numRows - 1;
            }
        }

        string result = "";
        for (int i = 0; i < resArray.Length; i++)
            result += resArray[i][0];

        return result;
    }

    public void Act()
    {
        try
        {
            result = Convert(testArr[testCase], testRows[testCase]);
        }
        catch
        {
            OutputHelper.Show($" test case: {testCase} testData: {testArr[testCase]}" +
                                $" rows number {testRows[testCase]}");
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
                            $" rows number {testRows[testCase]}");
    }

    public void ShowResult()
    {
        OutputHelper.Show($"    result: {result}");
    }
}