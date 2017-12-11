using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player_Movement : MonoBehaviour {

	public Ship_Data Ship;
	private float Hori_Move;
	private float Verti_Move;
	public bool Joysitck = false;
	public Transform Gun;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Fire();

		if (Joysitck == false)
		{
			KeyBoard_Movement();
		}

		if (Joysitck == true)
		{
			JoyStick_Movement();
		}

		Debug.DrawRay(this.transform.position, this.transform.up * 5f, Color.red);
		transform.Rotate(new Vector3(0,0,Hori_Move * Ship.Speed));
		if (Verti_Move >= 0)
		{
			this.transform.position += transform.up * Time.deltaTime * Ship.Speed;
		}
		else
		{
			this.transform.position += transform.up * Time.deltaTime * Ship.Speed / 2;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			BulletSpwan();
		}
	}

	void KeyBoard_Movement()
	{
		Hori_Move = Input.GetAxis("Ship_Horizontal");
		Verti_Move = Input.GetAxis("Ship_Vertical");
	} 

	void JoyStick_Movement()
	{
		Hori_Move = Input.GetAxis("Ship_Horizontal_Joystick");
		Verti_Move = Input.GetAxis("Ship_Vertical_Joystick");
	}

	public void OnValidate()
	{
		if (Ship != null)
		{
			Ship.OnValuesUpdated -= Asthetics;
			Ship.OnValuesUpdated += Asthetics; 
		}
		Asthetics();
	}

	public void Asthetics()
	{
		SpriteRenderer[] ShipBody = GetComponentsInChildren<SpriteRenderer>();

		ShipBody[0].color = Ship.ShipNose;
		ShipBody[1].color = Ship.ShipBody;
		ShipBody[2].color = Ship.ShipSideWings;
		ShipBody[3].color = Ship.ShipThrusters;

		this.gameObject.name = Ship.ShipName;
	}

	void OnValuesUpdated()
	{
		if (!Application.isPlaying)
		{
			Asthetics();
		}
	}

	void BulletSpwan()
	{
		GameObject bullet = GameObject.Instantiate(Ship.Bullet, Gun.position, this.transform.rotation, GameObject.FindGameObjectWithTag("Bullet_Holder").transform);
	}

	void Fire()
	{
		if (this.transform.GetChild(5).transform.localScale.x < 0.5f)
		{
			this.transform.GetChild(5).transform.localScale += new Vector3(0.1f, 0.1f, 0);
		}
		if (this.transform.GetChild(5).transform.localScale.x > 0.5f)
		{
			this.transform.GetChild(5).transform.localScale -= new Vector3(0.1f, 0.1f, 0);
		}
	}
}
