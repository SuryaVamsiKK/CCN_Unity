using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Autoenabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GameObject.FindGameObjectWithTag("Choice").GetComponent<Choice_Manager>().autofirecarry = this.gameObject.GetComponent<Toggle>().isOn;

	}
}
