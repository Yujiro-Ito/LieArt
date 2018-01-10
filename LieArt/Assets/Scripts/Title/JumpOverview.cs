using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class JumpOverview : MonoBehaviour {
	bool yet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PushButton(){
		if (yet == false) {
			yet = true;
			GameObject.Find ("FadeCanvas").GetComponent<Fade> ().FadeIn (0.25f, SwitchNext);
		}
	}

	private void SwitchNext(){
		SceneManager.LoadScene ("Overview");
	}
}
