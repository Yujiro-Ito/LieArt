﻿using UnityEngine;
using System.Collections;

public class SelectButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PushButton(){
		Sound.PlaySe ("select");
	}
}
