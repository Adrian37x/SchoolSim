using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScheduledTask
{
    public ClockTime startTime;
    public ClockTime endTime;
    public IActivity activity;

    public ScheduledTask(ClockTime startTime, ClockTime endTime, IActivity activity)
	{
        this.startTime = startTime;
        this.endTime = endTime;
		this.activity = activity;
	}
}
