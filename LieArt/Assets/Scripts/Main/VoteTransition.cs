using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VoteTransition : MonoBehaviour {
	bool yet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void VoteTransitionButton() {
		if (yet == false) {
			GameObject.Find ("FadeCanvas").GetComponent<Fade> ().FadeIn (0.25f, Next);
			yet = true;
		}
    }

	public void Next(){
		SceneManager.LoadScene ("Vote");
	}
}
