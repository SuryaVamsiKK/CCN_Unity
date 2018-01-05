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
	public float damagedelt = 4f;
	[SyncVar]
	public string resposinbleperson;

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
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ship")
		{
			collision.gameObject.GetComponent<Health>().Health_Reduction(damagedelt);
			Cmdkill();
			if (collision.gameObject.GetComponent<Health>().health <= 0)
			{
				GameObject.FindGameObjectWithTag("sts").gameObject.GetComponent<Stats>().killer = resposinbleperson + "   destroyed   " + collision.transform.parent.GetComponent<manager>().pname;
				GameObject.FindGameObjectWithTag("sts").gameObject.GetComponent<Stats>().fades = true;
			}
		}
	}

	private void OnValidate()
	{
		this.GetComponent<SpriteRenderer>().color = BulletColor;
	}

	[Command]
	void Cmdkill()
	{
		Destroy(this.gameObject);
		NetworkServer.Destroy(this.gameObject);
	}
}
