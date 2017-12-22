using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {


	public Slider Healthbar;
	private float health = 40f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		Healthbar.value = health;

	}

	public void Health_Reduction(float Damage)
	{
		health -= Damage;
	}
}
