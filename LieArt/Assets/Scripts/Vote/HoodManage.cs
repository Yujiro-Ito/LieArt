using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HoodManage : MonoBehaviour {
	[SerializeField]private GameObject _button = null;
	[SerializeField]private bool _attend = false;
	[SerializeField]private int _myNumber = 0;
	private VoteButton _voteButton;
	private FInger _finger;

	// Use this for initialization
	void Start () {
		_voteButton = GameObject.Find ("Manage").GetComponent<VoteButton> ();
		_finger = GameObject.Find ("Finger").GetComponent<FInger> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//データを代入
	public void AssignDatas(GameObject but, int ord, bool at){
		_button = but;
		_myNumber = ord;
		_attend = at;
		//欠席の場合、ボタンを非アクティブに
		if (_attend == false) {
			_button.SetActive (false);
		} else {
			_button.SetActive (true);
		}
		AddButtonEvent (_button.GetComponent<Button>());
	}

	//アクティブ非アクティブの切り替え
	public void AssignActive(bool state){
		if (_attend == false) {
			state = false;
		}
		_button.SetActive(state);
	}

	// ボタンに機能を付与する
	void AddButtonEvent(Button button) {
		button.onClick.AddListener(() => {
			this.ButtonPush();
		});
	}

	public void ButtonPush(){
		_voteButton.TmpButton (_myNumber);
		_finger.AssignPos (transform.position.x);
	}
}
