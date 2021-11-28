using System;
using System.Collections.Generic;
using System.Text;

    static class TimerController
    {

    private static List<Timer> activeTimers = new List<Timer>();

    public static void Update()
    {
        foreach (Timer timer in activeTimers)
        {
            timer.Update();
        }
    }

    private static void ActivateTimer(Timer timer)
    {
        activeTimers.Add(timer);
    }

    private static void DeactivateTimer(Timer timer)
    {
        activeTimers.Remove(timer);
    }

    public static void AddTimer(double time, Action callback)
    {
        Timer timer = new Timer(time);
        timer.AddListener(callback);
        ActivateTimer(timer);
    }

    public static void RemoveTimer(Timer timer)
    {
        DeactivateTimer(timer);
    }
}

