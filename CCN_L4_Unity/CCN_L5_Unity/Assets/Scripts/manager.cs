using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class manager : NetworkBehaviour {
	
	public GameObject[] ships;
	private bool limiter = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (isLocalPlayer)
		{
			if (limiter == false)
			{
				limiter = true;
				Cmdship(GameObject.FindGameObjectWithTag("Choice").GetComponent<Choice_Manager>().ShipChoice);
			}
		}

	}

	[Command]
	void Cmdship(int ship)
	{
		GameObject Ship = GameObject.Instantiate(ships[ship], Vector3.zero, Quaternion.identity);
		Ship.gameObject.GetComponent<Player>().parentNetId = this.gameObject.GetComponent<NetworkIdentity>().netId;
		NetworkServer.SpawnWithClientAuthority(Ship, this.gameObject);
	}
}
