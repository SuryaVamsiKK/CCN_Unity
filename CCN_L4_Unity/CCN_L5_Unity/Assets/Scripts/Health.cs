using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {


	public Slider Healthbar;
	[SyncVar (hook = "OnChangedHealth")] public float health = 40f;
	int currentpos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0)
		{
			this.transform.parent.GetComponent<manager>().currentPos();
			this.transform.parent.gameObject.SetActive(false);
		}

		if (!this.transform.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
		{
			if (this.Healthbar.value <= 0)
			{
				this.transform.parent.gameObject.SetActive(false);
			}
		}

	}

	public void Health_Reduction(float Damage)
	{

		if (!isServer)
		{
			return;
		}

		health -= Damage;
		if (health <= 0)
		{
			health = 0;
			//this.transform.parent.gameObject.SetActive(false);
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Destroyer")
		{
			Health_Reduction(100f);
		}
	}

	void OnChangedHealth(float healths)
	{
		Healthbar.value = healths;
	}
}
