using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameText : MonoBehaviour {
	GameManager.HoodsNumber hoodNumber;
    private Text _myText;

	// Use this for initialization
	void Start () {
		_myText = GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ChangeText(int num){
		switch (num) {
		case (int)GameManager.HoodsNumber.Red:
			_myText.text = "あかずきんの番です";
			break;
		case (int)GameManager.HoodsNumber.Blue:
			_myText.text = "あおずきんの番です";
			break;
		case (int)GameManager.HoodsNumber.White:
			_myText.text = "しろずきんの番です";
			break;
		case (int)GameManager.HoodsNumber.Black:
			_myText.text = "くろずきんの番です";
			break;
		case (int)GameManager.HoodsNumber.Pink:
			_myText.text = "ももずきんの番です";;
			break;
		case (int)GameManager.HoodsNumber.Sky:
			_myText.text = "そらずきんの番です";
			break;
		default:
			break;
		}
	}
}
