public static class DeltaTime
{
    private static double time = 0;
    public static double Time => time;

    public static void SetDeltaTime(double newTime)
    {
        time = newTime;
    }
}

