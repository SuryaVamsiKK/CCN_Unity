using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Movement : MonoBehaviour {

	public int dir = 0;
	float tempfloat;
	[Range (0,1)]
	public float speed = 0.5f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		tempfloat += Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.W) && dir != 1 && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
		{
			dir = 0;
		}
		if (Input.GetKeyDown(KeyCode.S) && dir != 0 && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
		{
			dir = 1;
		}
		if (Input.GetKeyDown(KeyCode.A) && dir != 3 && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S))
		{
			dir = 2;
		}
		if (Input.GetKeyDown(KeyCode.D) && dir != 2 && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S))
		{
			dir = 3;
		}

		if (tempfloat > speed)
		{
			this.transform.GetChild(0).GetComponent<SnakeHead>().LastPos = this.transform.GetChild(0).GetComponent<SnakeHead>().CurrentPos;

			if (dir == 0)
			{
				this.transform.GetChild(0).GetComponent<SnakeHead>().CurrentPos += new Vector2(0f, 1f);
			}
			if (dir == 1)
			{
				this.transform.GetChild(0).GetComponent<SnakeHead>().CurrentPos += new Vector2(0f, -1f);
			}
			if (dir == 2)
			{
				this.transform.GetChild(0).GetComponent<SnakeHead>().CurrentPos += new Vector2(-1f, 0f);
			}
			if (dir == 3)
			{
				this.transform.GetChild(0).GetComponent<SnakeHead>().CurrentPos += new Vector2(1f, 0f);
			}
			tempfloat = 0;
		}
	}
}
