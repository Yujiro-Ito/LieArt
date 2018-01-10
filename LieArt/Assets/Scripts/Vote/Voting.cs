using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Voting : MonoBehaviour {
	//----Constants----
	public Vector3 NORMAL_SIZE = new Vector3(1.5f, 1.5f);
	public Vector3 BIG_SIZE = new Vector3(2.5f, 2.5f);
	public Vector3 UP_POS = new Vector3 (0, 0.5f, 0);

	//-----Fields-----
	private bool[] _attends;
	private GameObject[] _objects;
	private int[] _order;
	private int _count;
	private int _memoryCount;
	private FInger _finger;
	private VoteButton _voteButton;
	private Text _descriptionText;
	public GameObject _instractor;
	private TextMaster _master;

	void Awake(){
		_count = 0;
		_voteButton = GetComponent<VoteButton> ();
		_finger = GameObject.Find ("Finger").GetComponent<FInger>();
		_master = _instractor.GetComponent<TextMaster>();
		_finger.InVisible ();
		_descriptionText = GameObject.Find ("Canvas/Panel/Description").GetComponent<Text>();
	}

	//メンバーの情報を取得するためのメソッド(相手は,ShuffleAndAttendents.cs)
	public void AssignMember(bool[] at, GameObject[] ob, int[] or){
		_attends = at;
		_objects = ob;
		_order = or;
		//最初の投票者を大きくする
		for (int i = 0; i < _attends.Length; i++) {
			if (_attends [i]) {
				_memoryCount = i;
				ob [i].transform.localScale = BIG_SIZE;
				ob [i].transform.position += UP_POS;
				ob [i].GetComponent<HoodManage> ().AssignActive (false);
				break;
			}
			_count++;
		}
		//上方のテキストを変える
		_master.ChangeText(_order[_count]);
	}
	
	// Update is called once per frame
	void Update () {
		_voteButton.AssignOpponent (_count);
	}

	public void Vote(int opNum){
		_finger.InVisible ();
		GameManager.GetInstance ().Vote (_count, opNum);
		bool finish = false;
		//人数をカウントアップ
		_count++;

		//最後の人だったら、終了通告を出す
		if (_count == _objects.Length) {
			finish = true;
		}

		//欠場者は飛ばす
		try{
			while (_attends [_count] == false && finish == false) {
				_count++;
				if (_count == _objects.Length) {
					finish = true;
					break;
				}
			}
		} catch(IndexOutOfRangeException e){
			finish = true;
		}
			
		if (finish) {
			//----最後の人ならば、終了する。----
			_master.ChangeText(100);
			_finger.InVisible ();
			_voteButton.Finish ();
			_finger.Finish ();
			_descriptionText.text = "次は結果発表だよ！";
			_descriptionText.fontSize = 30;
			StartCoroutine("FinishCount");
		} else {
			//----最後の人じゃない場合----
			//元の大きさにもどす
			for (int i = 0; i < _objects.Length; i++) {
				Vector2 pos = _objects [i].transform.position;
				pos.y = -1.2f;
				_objects [i].transform.position = pos;
				_objects [i].transform.localScale = NORMAL_SIZE;
				_objects [i].GetComponent<HoodManage> ().AssignActive (true);
			}
			//現在投票するずきんちゃんを大きくする
			_objects [_count].transform.position += UP_POS;
			_objects [_count].transform.localScale = BIG_SIZE;
			_objects [_count].GetComponent<HoodManage> ().AssignActive (false);
			_master.ChangeText (_order [_count]);
		}
	}

	public IEnumerator FinishCount(){
		yield return new WaitForSeconds (3);
		Sort ();
		SceneManager.LoadScene ("Result");
	}

	public void Sort(){
		
		int[] voteBox = GameManager.GetInstance ().GetVote;
		for(int i = 0; i < _order.Length - 1; i++){
			for(int j = _order.Length - 1; j > i; j--){
				if (_order [j] < _order [j - 1]) {
					//順番の入れ替え
					int tmp = _order [j];
					_order [j] = _order [j - 1];
					_order [j - 1] = tmp;

					//投票箱の入れかえ
					int voteTmp = voteBox[j];
					voteBox [j] = voteBox [j - 1];
					voteBox [j - 1] = voteTmp;

					//出欠情報も入れ替え
					bool tmpAttend = _attends[j];
					_attends [j] = _attends [j - 1];
					_attends [j - 1] = tmpAttend;
				}
			}
		}
		GameManager.GetInstance ().GetVote = voteBox;
	}
}
