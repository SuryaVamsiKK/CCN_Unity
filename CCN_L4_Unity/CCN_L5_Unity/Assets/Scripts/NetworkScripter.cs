﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkScripter : NetworkBehaviour {

	// Use this for initialization
	void Start () {

		if (isLocalPlayer)
			this.GetComponent<Player>().enabled = true;
		
	}
	
}
