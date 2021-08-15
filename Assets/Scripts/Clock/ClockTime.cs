using System;
using UnityEngine;

[Serializable]
public class ClockTime
{
	public WeekDay day;
	[Range(0, 23)]
	public int hour;
	[Range(0, 59)]
	public int minute;

	public ClockTime(WeekDay day, int hour, int minute)
	{
		this.day = day;
		this.hour = hour;
		this.minute = minute;
	}

	public bool Equals(ClockTime compare)
	{
		return day == compare.day && hour == compare.hour && minute == compare.minute;
	}
}
