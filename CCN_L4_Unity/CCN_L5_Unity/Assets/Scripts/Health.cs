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

		GameObject.FindGameObjectWithTag("Statsper").GetComponent<Text>().text = "";

	}
	
	// Update is called once per frame
	void Update () {

		if (this.transform.parent.GetComponent<NetworkIdentity>().isLocalPlayer)
		{
			if (health <= 0 || this.Healthbar.value <= 0)
			{
				GameObject.FindGameObjectWithTag("Statsper").GetComponent<Text>().color = new Color(25f, 255f, 255f, 255f);
				this.transform.parent.gameObject.SetActive(false);
			}

			if (GameObject.FindGameObjectsWithTag("Player").Length <= 1)
			{
				GameObject.FindGameObjectWithTag("Statsper").GetComponent<Text>().color = new Color(25f, 255f, 255f, 255f);
			}
			if(GameObject.FindGameObjectsWithTag("Player").Length > 1)
			{
				GameObject.FindGameObjectWithTag("Statsper").GetComponent<Text>().color = new Color(25f, 255f, 255f, 0f);
			}
		}

		if (!this.transform.parent.GetComponent<NetworkIdentity>().isLocalPlayer)
		{
			if (health <= 0 || this.Healthbar.value <= 0)
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
