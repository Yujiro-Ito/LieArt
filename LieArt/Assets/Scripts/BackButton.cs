using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {
	bool yet = false;
	public string _jumpScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void JumpButton(){
		if (yet == false) {
			yet = true;
			GameObject.Find ("FadeCanvas").GetComponent<Fade> ().FadeIn (0.25f, Push);
		}
	}

	public void Push(){
		SceneManager.LoadScene(_jumpScene);
	}
}
