using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text timeInfo;
    public float timeSpeed;

    private float timer = 0f;
    private WeekDay weekday = WeekDay.Monday;
    private int hour = 8;
    private int minute = 0;

	void Start()
	{
        timeInfo.text = GetTimeString();
	}

	void Update()
    {
        timer += Time.deltaTime * timeSpeed;

        if (timer > 1f)
        {
            timer = 0;
            minute++;

            if (minute % 60 == 0)
			{
                minute = 0;
                hour++;

                if (hour > 23)
				{
                    hour = 0;

                    if (weekday == WeekDay.Sunday)
					{
                        weekday = WeekDay.Monday;
					}
                    else
                    {
                        weekday++;
					}             
				}                 
            }                     

            timeInfo.text = GetTimeString();
			ClockEventManager.current.MinutePassed(new ClockTime(weekday, hour, minute));
		}
    }

    private string GetTimeString()
	{
        string ampm = "AM";
        int analogHour = hour;

        if (analogHour > 12)
		{
            analogHour -= 12;
            ampm = "PM";
		}

        return $"{weekday} {GetTimePartString(analogHour)}:{GetTimePartString(minute)} {ampm}";
    }

    private string GetTimePartString(int timePart)
	{
        return timePart.ToString().PadLeft(2, '0');
	}
}
