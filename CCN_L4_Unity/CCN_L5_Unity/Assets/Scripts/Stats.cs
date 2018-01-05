using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Stats : NetworkBehaviour {

	[SyncVar]
	public string killer;
	public Text txt;
	public float fadeOutTime;

	[HideInInspector]
	public bool fades = false;

	// Use this for initialization
	void Start () {

		//txt = this.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

		txt.text = killer;
		if (fades == true)
		{
			StartCoroutine(FadeOutRoutine());
			fades = false;
		}
		
	}

	public IEnumerator FadeOutRoutine()
	{
		Color originalColor = txt.color;
		for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
		{
			txt.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
			yield return null;
		}
	}
}
