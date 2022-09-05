public class Task12 : IAct, IShowCase, IShowResult
{
    private readonly int[] testArr;
    private int testCase;
    private string result;

    public Task12()
    {
        int quantity = 1000;
        testArr = new int[quantity];
        for(int i = 0; i < quantity; i++)
        {
            testArr[i] = i + 100;
        }
        testCase = 0;
        result = "";
    }

    public string IntToRoman(int num)
    {
        string res = "";
        int buffer = num;
        int digit = 0;
        int counter = -1;

        while(0 != buffer)
        {
            counter++;
            GetNextDigit();
            if((1 <= digit) && (3 >= digit))
            {
                FromOneToThree();
                continue;
            }
            if (4 == digit)
            {
                ForFour();
                continue;
            }
            if ((5 <= digit) && (8 >= digit))
            {
                FromFiveToEight();
                continue;
            }
            if(9 == digit)
            {
                ForNine();
            }
        }        
        return res;

        void GetNextDigit()
        {
            digit = buffer % 10;
            buffer = buffer / 10;
        }
        void FromOneToThree()
        {
            string[] symbol = { "I", "X", "C", "M" };
            string addSymbol = symbol[counter];

            for (int i = 0; i < digit; i++)
            {
                res = addSymbol + res;
            }
        }
        void ForFour()
        {
            string[] symbol = { "IV", "XL", "CD" };
            string addSymbol = symbol[counter];

            res = addSymbol + res;
        }
        void FromFiveToEight()
        {
            string[] symbol = { "V", "L", "D" };
            string[] secSymbol = { "I", "X", "C" };
            string addSymbol = symbol[counter];
            string addSecSymbol = secSymbol[counter];

            for (int i = 0; i < (digit - 5); i++)
            {
                addSymbol += addSecSymbol;
            }

            res = addSymbol + res;
        }
        void ForNine()
        {
            string[] symbol = { "IX", "XC", "CM" };
            string addSymbol = symbol[counter];

            res = addSymbol + res;
        }
    }

    public void Act()
    {
        try
        {
            result = IntToRoman(testArr[testCase]);
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