using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : Singleton<TimerManager>, IDisposable
{
    private readonly List<Coroutine> coroutines = new List<Coroutine>();
    public Coroutine CreateSingleTimer(float delay, Action action)
    {
        var coroutine = StartCoroutine(WaitFor(delay, action));
        coroutines.Add(coroutine);
        return coroutine;
    }
    
    public Coroutine CreateRepeatedTimer(float delay, Action action)
    {
        var coroutine = StartCoroutine(WaitForRepeated(delay, action));
        coroutines.Add(coroutine);
        return coroutine;
    }

    public void Dispose()
    {
        foreach (var coroutine in coroutines)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
    }

    IEnumerator WaitForRepeated(float delay, Action action)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            action.Invoke();
        }
    }
    IEnumerator WaitFor(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }

    public void StopTimer(Coroutine timer)
    {
        if (timer != null)
        {
            coroutines.Remove(timer);
            StopCoroutine(timer);
        }
    }
}
