using UnityEngine;
using System.Collections;

public class ShuffleAndAttends : MonoBehaviour {
	public GameObject[] _zukin;
	public GameObject[] _buttons;
	private bool[] _attends;
	public bool[] Attends{ get{ return _attends;}}
	private int[] _order = {0, 1, 2, 3, 4, 5};
	private SpriteRenderer _sprite;

	// Use this for initialization
	void Start () {
		_attends = GameManager.GetInstance ().HoodsMember;

		//出欠を確認
		for (int i = 0; i < _zukin.Length; i++) {
			_sprite = _zukin [i].GetComponent<SpriteRenderer> ();
			if (!_attends[i]) {
				//欠場の場合、透過処理
				var color = _sprite.color;
				color.a = 0.2f;
				_sprite.color = color;
			}
		}

		//ずきんたちをランダムに入れ替える
		/*for (int i = 0; i < _zukin.Length; i++) {
			int random = (int)Random.Range (0, _zukin.Length);
			//ずきんちゃんオブジェクトを入れ替え
			GameObject tmp = _zukin [random];
			_zukin [random] = _zukin [i];
			_zukin [i] = tmp;
			//出欠を入れ替え
			bool temp = _attends[i];
			_attends [i] = _attends[random];
			_attends [random] = temp;
			//オーダーを入れ替え
			int orderTmp = _order[i];
			_order [i] = _order [random];
			_order [random] = orderTmp;
		}*/

		//UIを並び替え、データをずきんたちに渡す
		for(int i = 0; i < _zukin.Length; i++){
			Vector2 newPos = new Vector2 (-7.5f + (i * 3), -1.2f);
			_zukin [i].transform.position = newPos;
			_zukin [i].GetComponent<HoodManage> ().AssignDatas (_buttons [i], _order [i], _attends [i]);
		}

		//投票クラスに情報を送る
		GetComponent<Voting>().AssignMember(_attends, _zukin, _order);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
