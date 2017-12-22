using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {


	public Slider Healthbar;
	[SyncVar (hook = "OnChangedHealth")] public float health = 40f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
			Debug.Log("DEAD");
		}

	}

	void OnChangedHealth(float healths)
	{
		Healthbar.value = healths;
	}
}
