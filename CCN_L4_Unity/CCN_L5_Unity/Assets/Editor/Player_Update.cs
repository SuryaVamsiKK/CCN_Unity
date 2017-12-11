using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class Player_Update : Editor {

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Player player = (Player)target;

		if (GUILayout.Button("Apply"))
		{ 
			player.Asthetics();
		}
	}
}
