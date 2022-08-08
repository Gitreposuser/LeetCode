public class Task6
{
    public Task6()
    {
        string[] testArr = { "PAYPALISHIRING",
                             "aaabbbcccdddeee",
                             "A",
                             "bb",
                             "bba",
                             "abb",
                             "ccc"};
        int[] testRows = { 4,
                           2,
                           3,
                           4,
                           5,
                           6,
                           7 };

        TestAllCases(testArr, testRows);
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

    private void TestAllCases(string[] testArr, int[] testRows)
    {
        int testCase = 0;
        try
        {
            for (; testCase < testArr.Length; testCase++)
            {
                Show($"test case: {testArr[testCase]}" +
                     $" result: {Convert(testArr[testCase], testRows[testCase])}");
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