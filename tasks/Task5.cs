public class Task5
{
    public Task5()
    {
        //string testString = "ccc";
        string testString = "12cabdbac78jkaba";

        Show(LongestPalindrome(testString));
    }
    public string LongestPalindrome(string s)
    {
        if (s.Length == 1)
            return s;

        s = s.ToUpper();

        const int shift = 48;
        short[] alreadyin = new short[43];
        short currentPos = 0;
        string subString = "";
        string result = "";

        while (currentPos < s.Length)
        {
            bool inList = alreadyin[s[currentPos] - shift] != 0;

            if (inList)
            {
                short start = (short)(alreadyin[s[currentPos] - shift] - 1);
                short length = (short)(currentPos - start + 1);
                alreadyin[s[currentPos] - shift] = (short)(currentPos + 1);
                subString = s.Substring(start, length);

                if (isPalindrom(subString))
                {
                    if (result.Length < subString.Length)
                        result = subString;
                }
            }
            else
            {
                alreadyin[s[currentPos] - shift] = (short)(currentPos + 1);
            }

            if (currentPos < s.Length)
            {
                currentPos++;
            }
        }

        if (result == "")
            result = (string)(s[0] + "");

        return result.ToLower();
    }
    private bool isPalindrom(string text)
    {
        if (text.Length == 1)
            return true;

        bool result = true;
        short start = 0;
        short end = (short)(text.Length - 1);

        while (start < end)
        {
            if (text[start] != text[end])
                return false;

            start++;
            end--;
        }

        return result;
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