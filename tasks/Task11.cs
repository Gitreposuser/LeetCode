public class Task11 : IAct, IShowCase, IShowResult
{
    private readonly int[][] testArr;
    private int testCase;
    private int result;

    public Task11()
    {
        //testArr = new int[][]
        //{
        //    new int[] { 4, 5, 6 },
        //    new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },
        //    new int[] { 1, 2, 4, 3 },
        //    new int[] { 2, 3, 4, 5, 18, 17, 6},
        //    new int[] {76,155,15,188,180,154,84,34,187,142,22,5,27,183,111,128,50,58,2,112,179,2,100,111,115,76,134,120,118,103,31,146,58,198,134,38,104,170,25,92,112,199,49,140,135,160,20,185,171,23,98,150,177,198,61,92,26,147,164,144,51,196,42,109,194,177,100,99,99,125,143,12,76,192,152,11,152,124,197,123,147,95,73,124,45,86,168,24,34,133,120,85,81,163,146,75,92,198,126,191}
        //};
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
        int counter = 0;

        ChoseSmallerElement();
        CheckMaxArea(CalculateArea(firstEl, secEl));

        while (true)
        {
            if(IsNextBigger())
            {
                ChoseSmallerElement();
                CheckMaxArea(CalculateArea(firstEl, secEl));
            }
            Tick();

            // Stop condition
            if(0 == secInd)
            {
                break;
            }
            counter++;
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
        void Tick()
        {
            if (0 == (counter % 2))
            {
                secInd--;
            }
            else
            {
                firstInd++;
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