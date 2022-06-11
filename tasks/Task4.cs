public class Task4
{
	public Task4()
	{
        int[] nums1 = { 10, 11, 12, 14, 17, 18, 29, 90 };
        //int[] nums1 = null;
        int[] nums2 = { 2, 3, 5, 6, 30 };
        //int[] nums2 = { 1, 3, 5, 6, 8, 9 };
        //int[] nums2 = null;

        double result = FindMedian(nums1, nums2);
        Show($" result is: {result}");
        Test(nums1, nums2);
    }
    public double FindMedian(int[] nums1, int[] nums2)
    {
        ShowArray(nums1);
        ShowArray(nums2);

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
    public void Show(string text)
    {
        Debug.WriteLine(text);
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
        int length = arr1.Length + arr2.Length;
        int ind1 = 0;
        int ind2 = 0;

        for (int i = 0; i < (length - 1); i++)
        {
            if (arr1[ind1] < arr2[ind2])
            {
                if (ind1 < (arr1.Length - 1))
                {
                    Debug.Write(arr1[ind1] + ", ");
                    ind1++;
                }
                else
                    Debug.Write(arr1[ind1] + ", " + arr2[ind2]);
            }
            else
            {
                if (ind2 < (arr2.Length - 1))
                {
                    Debug.Write(arr2[ind2] + ", ");
                    ind2++;
                }
                else
                    Debug.Write(arr2[ind2] + ", " + arr1[ind1]);
            }
        } // for

        Debug.WriteLine("");
    }
    public void Test(int[] arr1, int[] arr2)
    {
        Show(" Verification...");
        double result;

        if (arr1 == null)
        {
            ShowArray(arr2);
            result = GetMedian(arr2);
            Show(" median is: " + result);
            return;
        }
        if (arr2 == null)
        {
            ShowArray(arr1);
            result = GetMedian(arr1);
            Show(" median is: " + result);
            return;
        }

        int length = arr1.Length + arr2.Length;
        int ind1, ind2;
        ind1 = ind2 = 0;
        bool firstEnd, secondEnd;
        firstEnd = secondEnd = false;
        int[] mergedArr = new int[length];

        for (int i = 0; i < length; i++)
        {
            if (firstEnd)
            {
                mergedArr[i] = arr2[ind2];
                ind2++;
                continue;
            }
            if (secondEnd)
            {
                mergedArr[i] = arr1[ind1];
                ind1++;
                continue;
            }
            if (arr1[ind1] < arr2[ind2])
            {
                mergedArr[i] = arr1[ind1];
                if (ind1 < (arr1.Length - 1))
                    ind1++;
                else
                    firstEnd = true;
            }
            else
            {
                mergedArr[i] = arr2[ind2];
                if (ind2 < (arr2.Length - 1))
                    ind2++;
                else
                    secondEnd = true;
            }
        }

        Show(" merged array: ");
        ShowArray(mergedArr);

        result = GetMedian(mergedArr);

        Show(" median is: " + result);
    } // Test
}