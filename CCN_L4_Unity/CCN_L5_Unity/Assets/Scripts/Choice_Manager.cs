﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Choice_Manager : NetworkBehaviour {

	public int ShipChoice;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(this.gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
