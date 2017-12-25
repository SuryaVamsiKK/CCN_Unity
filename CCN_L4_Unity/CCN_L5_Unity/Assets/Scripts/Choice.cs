using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

	public int shipnum;
	 Choice_Manager selection_manager;
	//public string SceneName;
	 GameObject networksetup;
	public Text nms;

	private void Awake()
	{
		selection_manager = GameObject.FindGameObjectWithTag("Choice").GetComponent<Choice_Manager>();
		networksetup = GameObject.FindGameObjectWithTag("nets").gameObject;
	}

	// Use this for initialization
	void Start ()
	{
		networksetup.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		selection_manager.ShipChoice = shipnum;
		networksetup.SetActive(true);
		this.transform.parent.gameObject.SetActive(false);
		selection_manager.names = nms.text;
		//SceneManager.LoadScene(SceneName);
	}
}
