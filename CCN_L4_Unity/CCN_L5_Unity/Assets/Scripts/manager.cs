﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class manager : NetworkBehaviour {
	
	public GameObject[] ships;
	private bool limiter = false;
	[SyncVar]
	public string pname;
	public Text status;
	public Text status_per;
	bool enabler;
	int placeheld;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (status == null)
		{
			status = GameObject.FindGameObjectWithTag("Stats").GetComponent<Text>();
		}

		if (status_per == null)
		{
			status_per = GameObject.FindGameObjectWithTag("Statsper").GetComponent<Text>();
		}

		if (isLocalPlayer)
		{
			if (limiter == false)
			{
				limiter = true;
				Cmdship(GameObject.FindGameObjectWithTag("Choice").GetComponent<Choice_Manager>().ShipChoice);
				CmdName(GameObject.FindGameObjectWithTag("Choice").GetComponent<Choice_Manager>().names);
			}
		}
		this.gameObject.name = pname;
		status.text = GameObject.FindGameObjectsWithTag("Player").Length.ToString();
		if (GameObject.FindGameObjectsWithTag("Player").Length <= 1)
		{
			status.text = this.gameObject.name + " is the winner";
		}

		if(GameObject.FindGameObjectsWithTag("Player").Length > 1)
		{
			status.text = "Number of players left " + GameObject.FindGameObjectsWithTag("Player").Length;
		}
	}

	[Command]
	void Cmdship(int ship)
	{
		GameObject Ship = GameObject.Instantiate(ships[ship], Vector3.zero, Quaternion.identity);
		Ship.gameObject.GetComponent<Player>().parentNetId = this.gameObject.GetComponent<NetworkIdentity>().netId;
		NetworkServer.SpawnWithClientAuthority(Ship, this.gameObject);
	}

	[Command]
	void CmdName(string nms)
	{
		pname = nms;
	}

	public void currentPos()
	{
		if (enabler == false)
		{
			placeheld = GameObject.FindGameObjectsWithTag("Player").Length - 1;
			status_per.text = "You stood " + placeheld + " out of all";
			enabler = true;
		}
	}
}
