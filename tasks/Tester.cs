public static class Tester
{
    public static void Test()
    {
        Task10 task = new Task10();

        do
        {
            task.ShowCase();
            task.Act();
            task.ShowResult();
        } 
        while (task.IsNext());
    }
}