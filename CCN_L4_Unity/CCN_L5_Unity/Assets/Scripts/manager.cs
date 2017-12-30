using System.Collections;
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
	int placeheld;
	[HideInInspector]

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (status == null)
		{
			status = GameObject.FindGameObjectWithTag("Stats").GetComponent<Text>();
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
			//enabler = true;
		}

		if(GameObject.FindGameObjectsWithTag("Player").Length > 1)
		{
			status.text = "Number of players left " + GameObject.FindGameObjectsWithTag("Player").Length;
		}

		//if (this.transform.GetChild(0).GetComponent<Health>().Healthbar.value <= 0)
		//{
		//	currentPos();
		//}

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
}
