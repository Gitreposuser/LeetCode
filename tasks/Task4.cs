public class Task4 : IAct, IShowCase, IShowResult
{
    private int[][] testArr;
    private int[][] testArr2;
    private int testCase;
    private double result;

    public Task4()
	{
        testArr = new int[][] 
        { 
            new int[] { 10, 11, 12, 14, 17, 18, 29, 90 },
            new int[] { 3, 5, 8}
        };
        testArr2 = new int[][] 
        { 
            new int[] { 2, 3, 5, 6, 30 },
            new int[] { 7, 10, 11, 15 }
        };
        testCase = 0;
        result = 0;
    }
    public double FindMedian(int[] nums1, int[] nums2)
    {
        // When one of the arrays is empty
        if (nums1 == null)
            return GetMedian(nums2);
        if (nums2 == null)
            return GetMedian(nums1);

        int mergedLength = nums1.Length + nums2.Length;

        // When 1st array in front of 2nd
        if (nums1[nums1.Length - 1] < nums2[0])
        {
            int[] arr1, arr2;
            arr1 = nums1;
            arr2 = nums2;
            return MergedArrays(ref arr1, ref arr2);
        }
        // When 2nd array in front of 1st
        if (nums2[nums2.Length - 1] < nums1[0])
        {
            int[] arr1, arr2;
            arr1 = nums2;
            arr2 = nums1;
            return MergedArrays(ref arr1, ref arr2);
        }

        bool even = mergedLength % 2 == 0;
        if (even)
        {

        }
        else
        {
            int firstInd, secondInd;
            int inFirst, inSecond;
            int firstPrev, secondPrev;
            firstInd = GetMidIndex(0, nums1.Length);
            secondInd = GetMidIndex(0, nums2.Length);
            inFirst = nums1[firstInd];
            inSecond = nums2[secondInd];

            if (inFirst < inSecond)
            {

            }
            else
            {
                while (inFirst > inSecond)
                {
                    firstInd--;
                    secondInd++;
                    firstPrev = inFirst = nums1[firstInd];
                    secondPrev = inSecond = nums2[secondInd];
                }
            }
        }
        return 0;

        double MergedArrays(ref int[] arr1, ref int[] arr2)
        {
            bool even = mergedLength % 2 == 0;
            if (even)
            {
                int firstMid = (mergedLength / 2) - 1;
                int secondMid = mergedLength / 2;
                // Both pointers in first array
                bool bothInFirst = secondMid < arr1.Length;
                if (bothInFirst)
                {
                    return ((double)(arr1[firstMid] + arr1[secondMid]) / 2);
                }
                // Both pointers in second array
                bool bothInSecond = firstMid >= arr1.Length;
                if (bothInSecond)
                {
                    firstMid -= arr1.Length;
                    secondMid -= arr1.Length;
                    return ((double)(arr2[firstMid] + arr2[secondMid]) / 2);
                }
                // Splitted pointers
                return (double)(arr1[firstMid] + arr2[secondMid]) / 2;
            }
            else
            {
                int midIndex = mergedLength / 2;
                if (midIndex < arr1.Length)
                    return arr1[midIndex];
                else
                    return arr2[midIndex - arr1.Length];
            }
        }

        double GetMedian(int[] arr)
        {
            bool even = arr.Length % 2 == 0;
            int middle = GetMidIndex(0, arr.Length);
            double result;

            if (even)
                result = (double)(arr[middle - 1] + arr[middle]) / 2;
            else
                result = arr[middle];

            return result;
        }

        int GetMidIndex(int start, int end)
        {
            return (start + end) / 2;
        }
    }

    public double GetMedian(int[] arr)
    {
        bool even = arr.Length % 2 == 0;
        int middle = GetMidIndex(0, arr.Length);
        double result;

        if (even)
            result = (double)(arr[middle - 1] + arr[middle]) / 2;
        else
            result = arr[middle];

        return result;
    }

    public int GetMidIndex(int start, int end)
    {
        return (start + end) / 2;
    }

    public void Act()
    {
        try
        {
            result = FindMedian(testArr[testCase], testArr2[testCase]);
        }
        catch
        {
            OutputHelper.Show(" ERROR!!! ");
            OutputHelper.Show($" test case: {testCase} testData1: ");
            ShowArray(testArr[testCase]);
            OutputHelper.Show($" test case: {testCase} testData2: ");
            ShowArray(testArr2[testCase]);
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
        OutputHelper.Show($" test #: {testCase} case: ");
        ShowArray(testArr[testCase]);
        ShowArray(testArr2[testCase]);
    }

    public void ShowResult()
    {
        OutputHelper.Show(" Merged array : ");
        ShowMergedArray(testArr[testCase], testArr2[testCase]);
        OutputHelper.Show($"    result: {result}");
    }

    public void ShowArray(int[] arr1)
    {
        if (arr1 == null)
            return;
        for (int i = 0; i < arr1.Length; i++)
            Debug.Write(arr1[i] + ", ");
        Debug.WriteLine("");
    }

    public void ShowMergedArray(int[] arr1, int[] arr2)
    {
        bool firstEnd = false;
        bool secondEnd = false;
        int firstArrPos = 0;
        int secArrPos = 0;
        int resArrPos = 0;
        int[] result = new int[arr1.Length + arr2.Length];

        while(!(firstEnd && secondEnd))
        {
            if(firstEnd)
            {
                result[resArrPos] = arr2[secArrPos];
                resArrPos++;

                if (secArrPos < arr2.Length - 1)
                    secArrPos++;
                else
                    secondEnd = true;
                continue;
            }

            if (secondEnd)
            {
                result[resArrPos] = arr1[firstArrPos];
                resArrPos++;

                if (firstArrPos < arr1.Length - 1)
                    firstArrPos++;
                else
                    firstEnd = true;
                continue;
            }

            if (arr1[firstArrPos] < arr2[secArrPos])
            {
                result[resArrPos] = arr1[firstArrPos];

                if (firstArrPos < arr1.Length - 1)
                    firstArrPos++;
                else
                    firstEnd = true;
            }
            else
            {
                result[resArrPos] = arr2[secArrPos];

                if (secArrPos < arr2.Length - 1)
                    secArrPos++;
                else
                    secondEnd = true;
            }

            resArrPos++;
        }

        ShowArray(result);
    }
}