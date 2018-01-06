using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Choice_Manager : NetworkBehaviour {

	public int ShipChoice;
	public string names;
	public bool joystickcarry = false;
	public bool autofirecarry = false;

	// Use this for initialization
	void Start () {

		GameObject[] objs = GameObject.FindGameObjectsWithTag("Choice");
		//obj = GameObject.FindGameObjectWithTag("JOY").GetComponent<Toggle>();

		if (objs.Length > 1)
		{
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {

		//if (obj != null)
		//{
		//	joystickcarry = obj.isOn;
		//}
	//

	}
}
