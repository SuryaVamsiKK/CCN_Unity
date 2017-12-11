using UnityEngine;

[CreateAssetMenu()]
public class Ship_Data : Update_Data
{
	[Header("Asthetics")]
	public string ShipName;
	public Color ShipNose = Color.white;
	public Color ShipBody = Color.white;
	public Color ShipSideWings = Color.white;
	public Color ShipThrusters = Color.white;

	[Header("Properties")]
	[Range(1, 10)]
	public float Speed;
	public float FireRate;

	public GameObject Bullet;

	protected override void OnValidate()
	{
		base.OnValidate();
	}

}
