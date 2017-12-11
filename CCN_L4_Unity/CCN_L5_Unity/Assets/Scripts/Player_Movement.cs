using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public Ship_Data Ship;
	private float Hori_Move;
	private float Verti_Move;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = this.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

		keyBoard_Movement();
		this.transform.Translate(this.transform.up * Time.deltaTime * Ship.Speed);
		this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, this.transform.rotation.z + Hori_Move * Ship.Speed), Time.time);
	}

	private void FixedUpdate()
	{

	}

	void keyBoard_Movement()
	{
		Hori_Move = Input.GetAxis("Ship_Horizontal");
		Verti_Move = Input.GetAxis("Ship_Vertical");
	}

	void JoyStick_Movement()
	{
		Hori_Move = Input.GetAxis("Ship_Horizontal_Joystick");
		Verti_Move = Input.GetAxis("Ship_Vertical_Joystick");
	}

}
