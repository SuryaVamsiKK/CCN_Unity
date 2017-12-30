using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Stats : NetworkBehaviour {

	[SyncVar]
	public string killer;
	public Text txt;

	// Use this for initialization
	void Start () {

		//txt = this.GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

		txt.text = killer;
		
	}
}
