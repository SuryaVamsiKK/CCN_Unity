using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Data : ScriptableObject {

	public event System.Action OnValuesUpdated;
	public bool AutoUpdate;

	protected virtual void OnValidate()
	{
		if (AutoUpdate == true)
		{
			Notify();
		}
	}

	public void Notify()
	{
		if (OnValuesUpdated != null)
		{
			OnValuesUpdated();
		}
	}

}
