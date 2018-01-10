using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoteButton : MonoBehaviour {
	private int _tmpVoterNum;
	private int _tmpOpponentNum = 100;
	private GameObject _voteButton;
	private Text _descriptionText;
	private bool _finish = false;
	public GameObject _imageObj;
	private Image _image;
	private Text _voteText;

	// Use this for initialization
	void Start () {
		_descriptionText = GameObject.Find ("Canvas/Panel/Description").GetComponent<Text>();
		_voteButton = GameObject.Find ("Canvas/Panel/Vote");
		_descriptionText.text = "ウソズキンだと思うズキンちゃんをおして！";
		_voteButton.SetActive (false);
		//_image.SetActive (false);
		_image = _imageObj.GetComponent<Image>();
		_voteText = _imageObj.transform.FindChild ("VoteText").GetComponent<Text> ();
		_image.color = new Color(255, 255, 255, 0.5f);
		_voteText.color = new Color (0, 0, 0, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AssignOpponent(int num){
		_tmpVoterNum = num;
	}

	public void TmpButton(int op){
		if (_finish == false) {
			_tmpOpponentNum = op;
			_descriptionText.text = "そのズキンちゃんがあやしい？";
			_voteButton.SetActive (true);
			_image.color = new Color(255, 255, 255, 1);
			_voteText.color = new Color (0, 0, 0, 1);
		}
	}

	public void Finish(){
		_finish = true;
	}

	public void DecideButton(){
		if (_tmpOpponentNum <= 10) {
			_descriptionText.text = "ウソズキンだと思うずきんをおして！";
			_voteButton.SetActive (false);
			_image.color = new Color (255, 255, 255, 0.5f);
			_voteText.color = new Color (0, 0, 0, 0.5f);
			GetComponent<Voting> ().Vote (_tmpOpponentNum);
			_tmpOpponentNum = 100;
		}
	}
}
