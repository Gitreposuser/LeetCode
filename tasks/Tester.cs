public static class Tester
{
    public static void Test()
    {
        Task12 task = new Task12();

        do
        {
            task.ShowCase();
            task.Act();
            task.ShowResult();
        } 
        while (task.IsNext());
    }
}