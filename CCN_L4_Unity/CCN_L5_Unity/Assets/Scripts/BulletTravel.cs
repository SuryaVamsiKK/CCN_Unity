using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BulletTravel : NetworkBehaviour {

	[Range(0, 50)]
	public float Speed;
	public Color BulletColor;
	[SyncVar]
	public string ResponablePerson;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.position += this.transform.up * Time.deltaTime * Speed;
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Destroyer")
		{
			Destroy(this.gameObject);
		}

		if (collision.gameObject.tag == "Ship")
		{
			collision.GetComponent<Health>().Health_Reduction(4f); 
			Destroy(this.gameObject);
		}
	}

	private void OnValidate()
	{
		this.GetComponent<SpriteRenderer>().color = BulletColor;
	}
}
