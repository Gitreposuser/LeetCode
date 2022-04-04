public class Task3
{
	public Task3()
	{
        //string str = "aab";
        //string str = "bbbbb";
        //string str = "abba";
        //string str = "abdcecba";
        //string str = "abcdaefgh";
        //string str = "abcda1aefgh";
        string str = "bcdaa12345";

        int result = LengthOfLongestSubstring2(str);

        Debug.WriteLine("result: " + result);
    }
    public int LengthOfLongestSubstring(string s)
    {
        bool[] symbol = new bool[128];
        ushort startPos = 0;
        ushort index = 0;
        byte counter = 0;
        byte maxLenght = 0;

        while (index < s.Length)
        {
            if (symbol[s[index]])
            {
                // Found end of sequence
                if (maxLenght < counter)
                    maxLenght = counter;

                counter = 0;
                index = startPos;
                startPos++;

                // Clear array
                Array.Clear(symbol, 0, symbol.Length);
            }
            else
            {
                // Add to array
                symbol[s[index]] = true;
                counter++;
            }
            index++;
        }

        if (maxLenght < counter)
            maxLenght = counter;

        return (int)maxLenght;
    }
    public int LengthOfLongestSubstring2(string s)
    {
        ushort[] symbol = new ushort[128];
        ushort lastRepeat = 0;
        ushort index = 0;
        ushort tempChar = 0;
        byte counter = 0;
        byte maxLenght = 0;

        while (index < s.Length)
        {
            tempChar = symbol[s[index]];

            if (tempChar != 0 &&
                tempChar > lastRepeat)  // Repeat detected
            {
                if (tempChar == index)   // Instant repeat
                    counter = 1;
                else// Spaced repeat
                {
                    if (tempChar < lastRepeat)   // Already have internal repeat
                        counter = 1;
                    else// Without internal repeat
                        counter = (byte)((index - tempChar) + 1);
                }
                // Change postion of last repeat
                lastRepeat = tempChar;
            }
            else
                counter++;

            // Remember new repeat position
            symbol[s[index]] = (ushort)(index + 1);
            index++;

            if (maxLenght < counter)
                maxLenght = counter;
        }

        return (int)maxLenght;
    }
}