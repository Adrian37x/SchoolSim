using System;
using UnityEngine;

public class ClockEventManager : MonoBehaviour
{
    public static ClockEventManager current;

    void Awake()
    {
        current = this;
    }

    public event Action<ClockTime> onMinutePassed;
    public void MinutePassed(ClockTime clockTime)
    {
        onMinutePassed?.Invoke(clockTime);
    }
}
