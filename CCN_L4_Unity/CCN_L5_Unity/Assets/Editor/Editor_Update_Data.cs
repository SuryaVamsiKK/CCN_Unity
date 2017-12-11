using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Update_Data), true)]
public class Editor_Update_Data : Editor {

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Update_Data Data = (Update_Data)target;

		GUILayout.Space(20f);
		if (GUILayout.Button("Update"))
		{
			Data.Notify();
		}
	}
}
