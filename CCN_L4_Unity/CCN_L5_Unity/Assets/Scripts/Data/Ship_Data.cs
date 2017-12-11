﻿using UnityEngine;

[CreateAssetMenu()]
public class Ship_Data : Update_Data
{
	[Header("Asthetics")]
	public string ShipName;
	public Color ShipColor;

	[Header("Properties")]
	public float Speed;
	public float FireRate;

	public GameObject Bullet;

	protected override void OnValidate()
	{
		base.OnValidate();
	}

}
