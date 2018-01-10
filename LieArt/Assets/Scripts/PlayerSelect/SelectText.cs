using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectText : MonoBehaviour {
    private GameObject SwichButton;
	private Text _myText;
	private int _joinNumber;
    private Text nextPlayerText;
    private Text switchText;

    private Color defaultColor;
    private Color changeColor;
    private Color defaultTextColor;
    private Color changeTextColor;

    // Use this for initialization
    void Start () {
        defaultColor = new Color(255,255,255,255);
        changeColor = new Color(255,255,255,0.5f);
        defaultTextColor = new Color(0, 0, 0, 255);
        changeTextColor = new Color(0, 0, 0, 0.5f);

		_myText = this.GetComponent<Text>();
		_joinNumber = 0;
		for(int i = 0; i < GameManager.GetInstance().HoodsMember.Length; i++){
			GameManager.GetInstance().HoodsMember[i] = false;
		}
        switchText = GameObject.Find("SwitchText").GetComponent<Text>();
        SwichButton = GameObject.Find("SwitchButton");
        nextPlayerText = GameObject.Find("NextPlayerText").GetComponent<Text>();
		SwichButton.GetComponent<Image>().color = new Color(255,255,255,0.5f);
        switchText.color = changeColor;
	}
	
	// Update is called once per frame
	void Update () {
		_joinNumber = 0;
		for(int i = 0; i < GameManager.GetInstance().HoodsMember.Length; i++){
			if(GameManager.GetInstance().HoodsMember[i] == true){  //参加
				_joinNumber += 1;
			}
		}
		if(_joinNumber < 3){
			_myText.text = "3人以上選んでね!";
            SwichButton.GetComponent<Image>().color = changeColor;
            switchText.color = changeTextColor;
		}else{
			_myText.text = "今"+ _joinNumber + "人選んでいるよ！";
            SwichButton.GetComponent<Image>().color = defaultColor;
            switchText.color = defaultTextColor;
		}
        if ((_joinNumber + 1) != 7) {
            nextPlayerText.text = (_joinNumber + 1) + "プレイヤーを選んでください";
        } else {
            nextPlayerText.text = "最大人数だよ";
        }
	}
}
