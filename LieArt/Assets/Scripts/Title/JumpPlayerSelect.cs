using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class JumpPlayerSelect: MonoBehaviour {
	Fade _fade;
	bool yet = false;

	// Use this for initialization
	void Start () {
		_fade = GameObject.Find ("FadeCanvas").GetComponent<Fade> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CallFadeOut(){
		if (yet == false) {
			GameObject.Find ("FadeCanvas").GetComponent<Fade> ().FadeIn (0.25f, PushButton);
			yet = true;
		}
	}

	public void PushButton(){
		GameManager.GetInstance ().InitializeNumber ();
		GameManager.GetInstance ().ResetHoods ();
		SceneManager.LoadScene ("PlayerSelect");
	}
}
