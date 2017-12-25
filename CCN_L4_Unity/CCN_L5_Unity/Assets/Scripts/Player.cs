using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

	[SyncVar]
	public NetworkInstanceId parentNetId;

	[Header("The Ship")]
	public Ship_Data Ship;

	[Header("Requirements")]
	public Transform Gun;

	[Header("Controls")]
	public bool Joysitck = false;
	public bool autoFire = false;


	private float waitfire;
	private float Hori_Move;
	private float Verti_Move;
	private bool joystickfirecontrol = false;

	// Use this for initialization
	void Start () {
		
		if (parentNetId != null)
		{
			//Debug.Log("Attached item net id:" + parentNetId);
			GameObject parentObject = ClientScene.FindLocalObject(parentNetId);
			transform.SetParent(parentObject.transform);
			//Debug.Log(this.transform.parent.GetComponent<NetworkIdentity>().isLocalPlayer);
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (!this.transform.parent.GetComponent<NetworkIdentity>().isLocalPlayer)
		{
			return;
		}

		//Fire();

		Debug.DrawRay(this.transform.position, this.transform.up * 5f, Color.red);
		transform.Rotate(new Vector3(0,0,Hori_Move * Ship.Speed));
		if (Verti_Move >= 0)
		{
			this.transform.position += transform.up * Time.deltaTime * Ship.Speed;
		}

		if (Joysitck == false)
		{
			if (Verti_Move < 0)
			{
				this.transform.position += transform.up * Time.deltaTime * Ship.Speed / 2;
			}
		}

		if (Joysitck == true)
		{
			if (Input.GetAxis("SlowDown") == 0)
			{
				this.transform.position += transform.up * Time.deltaTime * Ship.Speed / 2;
			}
		}



		if (Joysitck == false)
		{
			KeyBoard_Movement();
			if (autoFire == false)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					CmdBulletSpwan();
					waitfire = 0;
				}
			}
		}

		if (Joysitck == true)
		{
			JoyStick_Movement();
			if (autoFire == false)
			{
				if (Input.GetAxis("Ship_Fire_Joystick") == 1 && joystickfirecontrol == false)
				{
					joystickfirecontrol = true;
					CmdBulletSpwan();
					waitfire = 0;
				}
				if (Input.GetAxis("Ship_Fire_Joystick") == 0)
				{
					joystickfirecontrol = false;
				}
			}
		}


		if (autoFire == true)
		{
			if (waitfire <= 0)
			{
				CmdBulletSpwan();
				waitfire = 1f;
			}
		}

		waitfire -= Time.deltaTime * Ship.FireRate;

		if (waitfire <= 0f)
		{
			waitfire = 0f;
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

	[Command]
	void CmdBulletSpwan()
	{
			GameObject bullet = GameObject.Instantiate(Ship.Bullet, Gun.position, this.transform.rotation);
			Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
			NetworkServer.Spawn(bullet);
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
