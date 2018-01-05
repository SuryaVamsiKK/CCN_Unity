using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour {

	public Vector2 CurrentPos;
	public Vector2 LastPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.parent.GetChild(1).GetComponent<TailMovement>().CurrentPos = LastPos;

		
	}
}
