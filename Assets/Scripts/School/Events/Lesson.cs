using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Lesson
{
    public ClockTime startTime;
    public ClockTime endTime;
    public Subject subject;

    public ScheduledTask ToScheduledTask()
    {
        IActivity activity = new AttendClassActivity(subject);

        return new ScheduledTask(startTime, endTime, activity);
    }
}
