public class Task11 : IAct, IShowCase, IShowResult
{
    private readonly int[][] testArr;
    private int testCase;
    private int result;

    public Task11()
    {
        int arrayQuantity = 100;
        testArr = new int[arrayQuantity][];

        for(int i = 0; i < arrayQuantity; i++)
        {
            testArr[i] = GenerateArray(2, 10);
        }

        testCase = 0;
        result = 0;
    }
    
    private int MaxArea(int[] height)
    {
        int maxArea = 0;
        int firstInd = 0;
        int firstEl = 0;
        int secInd = height.Length - 1;
        int secEl = height.Length - 1;
        int minHeight = 0;

        ChoseSmallerElement();
        CheckMaxArea(CalculateArea(firstEl, secEl));

        while (firstInd < secInd)
        {
            if(IsNextBigger())
            {
                ChoseSmallerElement();
                CheckMaxArea(CalculateArea(firstEl, secEl));
            }
            NextStep();
        }
        return maxArea;

        int CalculateArea(int ind1, int ind2)
        {
            int area = 0;
            if(ind2 > ind1)
            {
                area = (ind2 - ind1) * minHeight;
            }
            else
            {
                area = (ind1 - ind2) * minHeight;
            }
            return area;
        }
        void CheckMaxArea(int area)
        {
            if (maxArea < area)
            {
                maxArea = area;
            }
        }
        void ChoseSmallerElement()
        {
            if (height[firstEl] < height[secEl])
            {
                minHeight = height[firstEl];
            }
            else
            {
                minHeight = height[secEl];
            }
        }
        bool IsNextBigger()
        {
            if((height[firstInd] > height[firstEl]) &&
               (firstInd != secEl))
            {
                firstEl = firstInd;
                return true;
            }
            if((height[secInd] > height[secEl]) &&
               (secInd != firstEl))
            {
                secEl = secInd;
                return true;
            }
            return false;
        }
        void NextStep()
        {
            if(height[firstEl] < height[secEl])
            {
                firstInd++;
            }
            else
            {
                secInd--;
            }
        }
    }

    private int MaxAreaTest(int[] height)
    {
        int maxArea = 0;
        int minHeight = 0;

        for(int j = 0; j < height.Length; j++)
        {
            for(int i = j; i < height.Length; i++)
            {
                if(height[i] < height[j])
                {
                    minHeight = height[i];
                }
                else
                {
                    minHeight = height[j];
                }
                int area = (i - j) * minHeight;
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }
        }
        return maxArea;
    }

    private int[] GenerateArray(int minLenght, int maxLenght)
    {
        Random rand = new Random();
        int lenght = rand.Next(minLenght, maxLenght);
        int[] array = new int[lenght];
        for(int i = 0; i < lenght; i++)
        {
            array[i] = rand.Next(100000);
        }
        return array;
    }

    public void Act()
    {
        try
        {
            result = MaxArea(testArr[testCase]);
            int expectedRes = MaxAreaTest(testArr[testCase]);
            if (result != expectedRes)
            {
                OutputHelper.Show($" *** {result} != {expectedRes} Error!!! ***");
            }
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
        string testDataStr = "";
        for(int i = 0; i < testArr[testCase].Length; i++)
        {
            testDataStr += testArr[testCase][i] + ", ";
        }
        OutputHelper.Show($" test #: {testCase} case: {testDataStr}");
    }

    public void ShowResult()
    {
        OutputHelper.Show($"    result: {result}");
    }
}