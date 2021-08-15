using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class PersonAI : MonoBehaviour
{
    [Header("Information")]
    public Person person;

    [Header("Components")]
    public Animator animator;

    [HideInInspector]
    public NavMeshAgent agent;

    protected readonly Queue<ScheduledTask> tasks = new Queue<ScheduledTask>();
    protected ScheduledTask currentTask;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // subscribe to clock events
        ClockEventManager.current.onMinutePassed += UpdateActivity;
    }

    private void OnDestroy()
    {
        // unsubscribe to clock events
        ClockEventManager.current.onMinutePassed -= UpdateActivity;
    }

    public virtual void SetData(Person person, Lesson[] timetable)
	{
        this.person = person;

        foreach (Lesson lesson in timetable)
		{
            tasks.Enqueue(lesson.ToScheduledTask());
		}

        tasks.OrderBy(task => task.startTime.day);
	}

    private void UpdateActivity(ClockTime clockTime)
    {
        // if task is finished
        if (currentTask != null && currentTask.endTime.Equals(clockTime))
        {
            currentTask.activity.OnEnd(this);
        }

        if (IsNextTaskReady(clockTime))
        {
            if (currentTask != null)
            {
                currentTask.activity.OnEnd(this);
            }

            ScheduledTask task = tasks.Dequeue();

            // handle multiple tasks with the same start time
            while (IsNextTaskReady(clockTime))
            {
                tasks.Dequeue();
            }

            task.activity.OnStart(this);
            currentTask = task;
        }
    }

    private bool IsNextTaskReady(ClockTime clockTime)
    {
        return tasks.Count > 0 && tasks.Peek().startTime.Equals(clockTime);
    }

    private void Update()
    {
        animator.SetFloat("magnitude", agent.velocity.magnitude);

        if (currentTask is null)
            // TODO: Placeholder activity (ex. Reading under a tree)
            return;

        currentTask.activity.OnUpdate(this);
    }
}
