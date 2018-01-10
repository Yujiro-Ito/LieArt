using UnityEngine;
using System.Collections;

public class Tweet : MonoBehaviour {
	public string text;
	public string URL;
	string imagePath{
		get
		{
			//保存先を指定
			return Application.persistentDataPath + "/image.png";
		}
	}

	public void TweetButton(){
		StartCoroutine ("Share");
	}

	public IEnumerator Share(){

		//スクリーンショットを撮影
		Application.CaptureScreenshot ("image.png");
		yield return new WaitForEndOfFrame ();

		if (Application.platform == RuntimePlatform.Android) {
			text = "テスト";
			URL = "特になし！";

		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			text = "テスト";
			URL = "特になし！";
		}
		yield return new WaitForSeconds (1);
		SocialConnector.Share (text, URL, imagePath);
	}
}
