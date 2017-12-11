using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player_Movement : MonoBehaviour {

	public Ship_Data Ship;
	private float Hori_Move;
	private float Verti_Move;
	public bool Joysitck = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

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
		this.transform.position += transform.up * Time.deltaTime * Ship.Speed;
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

	void OnValidate()
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

		for (int i = 0; i < ShipBody.Length; i++)
		{
			ShipBody[i].color = Ship.ShipColor;
		}

		this.gameObject.name = Ship.ShipName;
	}

	void OnValuesUpdated()
	{
		if (!Application.isPlaying)
		{
			Asthetics();
		}
	}

}
