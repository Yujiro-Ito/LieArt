using UnityEngine;
using System.Collections;

public class FadeOutManage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("FadeCanvas").GetComponent<Fade> ().FadeOut (0.25f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
