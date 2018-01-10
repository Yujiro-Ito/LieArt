using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManualClose : MonoBehaviour {
	bool yet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void SceneClose() {
		if (yet == false) {
			StartCoroutine ("Jump");
			yet = true;
		}
        
    }

	public IEnumerator Jump(){
		GameObject.Find ("FadeCanvas").GetComponent<Fade> ().FadeIn (0.25f);
		yield return new WaitForSeconds (0.25f);
		GameObject.Find ("FadeCanvas").GetComponent<Fade> ().FadeOut (0.25f);
		SceneManager.UnloadScene("Manual");
	}
}
