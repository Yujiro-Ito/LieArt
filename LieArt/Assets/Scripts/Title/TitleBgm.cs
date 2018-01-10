using UnityEngine;
using System.Collections;

public class TitleBgm : MonoBehaviour {

	// Use this for initialization
	void Awake(){
		Application.targetFrameRate = 60;
		GameManager.GetInstance ().LoadBgm ();
		Sound.PlayBgm ("title");

		//画面の向き固定
		// 縦
		Screen.autorotateToPortrait = false;
		// 左
		Screen.autorotateToLandscapeLeft = true;
		// 右
		Screen.autorotateToLandscapeRight = false;
		// 上下反転
		Screen.autorotateToPortraitUpsideDown = false;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
