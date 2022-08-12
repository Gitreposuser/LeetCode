public class OutputHelper
{
    public static void Show(string message)
    {
#if DEBUG
        Debug.WriteLine(message);
#else
        Console.WriteLine(message);
#endif
    }
}