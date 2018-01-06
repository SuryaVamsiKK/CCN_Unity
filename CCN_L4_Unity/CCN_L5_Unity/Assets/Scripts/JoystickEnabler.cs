using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GameObject.FindGameObjectWithTag("Choice").GetComponent<Choice_Manager>().joystickcarry = this.gameObject.GetComponent<Toggle>().isOn;
		
	}
}
