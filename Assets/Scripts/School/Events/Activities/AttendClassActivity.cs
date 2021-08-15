using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendClassActivity : IActivity
{
	private Subject subject;

	public AttendClassActivity(Subject subject)
	{
		this.subject = subject;
	}

	public void OnStart(PersonAI personAI)
	{
		Transform classroom = SchoolManager.current.GetClassroom(subject);

		personAI.agent.SetDestination(classroom.position + new Vector3(Random.Range(0.2f, 3.8f), 0, Random.Range(-0.2f, -3.8f)));
	}

	public void OnUpdate(PersonAI personAI)
	{
		
	}

	public void OnEnd(PersonAI personAI)
	{

	}
}
