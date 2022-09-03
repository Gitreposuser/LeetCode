public static class Tester
{
    public static void Test()
    {
        Task11 task = new Task11();

        do
        {
            task.ShowCase();
            task.Act();
            task.ShowResult();
        } 
        while (task.IsNext());
    }
}