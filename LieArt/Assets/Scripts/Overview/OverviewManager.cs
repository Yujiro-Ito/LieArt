using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OverviewManager : MonoBehaviour {
    public GameObject View1;

    private int count;

	// Use this for initialization
	void Start () {
        count = 0;
		Sound.PlayBgm ("overView");
	}
	
	// Update is called once per frame
	void Update () {
        if (count == 111) {
            View1.SetActive(false);
        } else if (count >= 1) {
            SceneManager.LoadScene("Title");
        }
	}

    public void Count() {
        count++;
    }
}
