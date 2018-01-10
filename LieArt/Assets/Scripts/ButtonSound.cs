using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour {
	public bool _next;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayButtonSe(){
		if (_next)
			Sound.PlaySe ("next");
		else
			Sound.PlaySe ("back");
	}

	public void PlaySelectButton(){
		Sound.PlaySe ("select");
	}
}
