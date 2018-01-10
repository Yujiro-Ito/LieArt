using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextMaster : MonoBehaviour {
	private Text _myText;
	
	GameManager.HoodsNumber hoodNumber;
	// Use this for initialization
	void Start () {
		_myText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ChangeText(int num){
		switch (num) {
		case (int)GameManager.HoodsNumber.Red:
			_myText.text = "あかずきんの番です";
			_myText.color = Color.red;
			break;
		case (int)GameManager.HoodsNumber.Blue:
			_myText.text = "あおずきんの番です";
			_myText.color = Color.blue;
			break;
		case (int)GameManager.HoodsNumber.White:
			_myText.text = "しろずきんの番です";
			_myText.color = Color.gray;
			break;
		case (int)GameManager.HoodsNumber.Black:
			_myText.text = "くろずきんの番です";
			_myText.color = Color.black;
			break;
		case (int)GameManager.HoodsNumber.Pink:
			_myText.text = "ももずきんの番です";
			_myText.color = Color.magenta;
			break;
		case (int)GameManager.HoodsNumber.Sky:
			_myText.text = "そらずきんの番です";
			_myText.color = Color.cyan;
			break;
		default:
			_myText.text = "とうひょうかんりょう！";
			_myText.color = Color.black;
			break;
		}
	}
}
