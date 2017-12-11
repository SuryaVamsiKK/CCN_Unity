using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player_Movement))]
public class Player_Update : Editor {

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Player_Movement player = (Player_Movement)target;

		if (GUILayout.Button("Apply"))
		{
			player.Asthetics();
		}
	}
}
