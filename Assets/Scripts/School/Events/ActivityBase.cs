using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivityBase
{
	public abstract void OnStart(PersonAI personAI);

	public abstract void OnUpdate(PersonAI personAI);

	public abstract void OnEnd(PersonAI personAI);
}
