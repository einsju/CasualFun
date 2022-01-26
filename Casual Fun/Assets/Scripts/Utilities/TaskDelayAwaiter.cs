using System;
using System.Threading.Tasks;

public static class TaskDelayAwaiter
{
    public static async void Wait(Action callback, int delay = 300)
    {
        await Task.Delay(delay);
        callback();
    }
}
