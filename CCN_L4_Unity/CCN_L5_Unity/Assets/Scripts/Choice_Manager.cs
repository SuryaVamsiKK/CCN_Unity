using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Choice_Manager : NetworkBehaviour {

	public int ShipChoice;
	public string names;

	// Use this for initialization
	void Start () {

		GameObject[] objs = GameObject.FindGameObjectsWithTag("Choice");

		if (objs.Length > 1)
		{
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
