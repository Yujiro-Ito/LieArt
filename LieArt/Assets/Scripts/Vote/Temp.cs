using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Temp : MonoBehaviour {
	private float frameCounter;

	// Use this for initialization
	void Start () {
		frameCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		frameCounter += Time.deltaTime;
		if (frameCounter >= 3) {
			SceneManager.LoadScene ("Main");
		}
	}
}
