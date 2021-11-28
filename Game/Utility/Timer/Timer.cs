using System;


class Timer
{
    private event Action OnFinished; 
    private double timeInSeconds;
    private double currentTimeInSeconds;

    public Timer(double timeInSeconds)
    {
        this.timeInSeconds = timeInSeconds;
    }

    public void Reset()
    {
        currentTimeInSeconds = 0;
    }

    public void Update()
    {
        currentTimeInSeconds += DeltaTime.Time;

        if(currentTimeInSeconds >= timeInSeconds)
        {
            OnFinished.Invoke();
            Reset();
        }
    }

    public void AddListener(Action a)
    {
        OnFinished += a;
    }

    public void RemoveListener(Action a)
    {
        OnFinished -= a;
    }
}

