using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {
	private int _joinNumber;
	private int[] _order;
	private bool yet = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void JumpThemeCheck(){
		//参加人数のカウント
		for(int i = 0; i < GameManager.GetInstance().HoodsMember.Length; i++){
			if(GameManager.GetInstance().HoodsMember[i]){  //参加
				_joinNumber += 1;
			}
		}
		if (_joinNumber >= 3) {
			if (yet == false) {
				GameObject.Find ("FadeCanvas").GetComponent<Fade> ().FadeIn (0.25f, Jump);
				yet = true;
			}
		} else {
			_joinNumber = 0;
		}
	}

	public void Jump(){

		//周回数を決定
		if (GameManager.GetInstance ().JoingNumber () <= 4) {
			GameManager.GetInstance ().Turn = UnityEngine.Random.Range (1, 3);
		} else {
			GameManager.GetInstance ().Turn = 1;
		}

		//参加者の番号を登録
		_order = new int[_joinNumber];
		int count = 0;
		for (int i = 0; i < GameManager.GetInstance().HoodsMember.Length; i++) {
			if (GameManager.GetInstance ().HoodsMember [i]) {
				_order [count] = i;
				count++;
			}
		}

		//テーマを知らない人を決定と、周回数の決定
		if(_joinNumber >= 3){
			int unkown = Random.RandomRange (0, _joinNumber);
			GameManager.GetInstance().UnknownPerson = unkown;  //テーマを知らない人を決める
			GameManager.GetInstance().UnknownSuffix = _order[unkown];
			SceneManager.LoadScene ("ThemeCheck");
		}else{
			_joinNumber = 0;
		}
	}
}
