using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour {

	public int shipnum;
	public Choice_Manager selection_manager;
	public string SceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		selection_manager.ShipChoice = shipnum;
		SceneManager.LoadScene(SceneName);
	}
}
