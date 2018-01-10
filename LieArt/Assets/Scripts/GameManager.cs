using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager {
	//変数
	private string _invisibleTheme;  //一部の人が見れるテーマ
	private string _visibleTheme;    //全員が見れるテーマ
	private int _turn = 1;           //周回数
	private bool[] _hoodsArray = new bool[6];      //ゲームに参加する頭巾ちゃんたちを管理する配列
	private int[] _vote = new int[6];			 //投票数
	private int _unknownPerson = 0;  //テーマを知らない人の添字
	private int _unknownSuffix = 0;
	private bool _loadBgm = false;
	private Texture2D _drawResult;

	//ゲッターセッターをひとつにまとめた変数
	public string InvisibleTheme{ get{ return _invisibleTheme; } set{ _invisibleTheme = value; }}
	public string VisibleTheme{ get{ return _visibleTheme; } set{ _visibleTheme = value; }}
	public int Turn{ get{ return _turn; } set{ _turn = value; }}
	public bool[] HoodsMember{ get{ return _hoodsArray; } set{ _hoodsArray = value; }}
	public int[] GetVote{ get{ return _vote; } set{ _vote = value; }}
	public int UnknownPerson{ get{ return _unknownPerson; } set{ _unknownPerson = value; }}
	public int UnknownSuffix{ get{ return _unknownSuffix; } set{ _unknownSuffix = value; }}
	public Texture2D DrawResult{ get{ return _drawResult;} set{ _drawResult = value; }}

	//頭巾ちゃんたちの名前の列挙型
	public enum HoodsNumber : int{
		Red = 0,
		Blue, White, Black, Pink, Sky
	}

	//シングルトンの生成、呼び出し。
	public static GameManager _singleton;
	public static GameManager GetInstance(){
		return _singleton ?? (_singleton = new GameManager ());
	}

	//変数の初期化
	public void InitializeNumber(){
		_invisibleTheme = "";
		_visibleTheme = "";
		_turn = 0;
	}

	//ゲーム参加の頭巾ちゃんたちを初期化する
	public void ResetHoods(){
		_hoodsArray = new bool[6];
		for (int i = 0; i < _hoodsArray.Length; i++) {
			_hoodsArray [i] = false;
		}
	}

	//ゲームの参加人数を返すメソッド
	public int JoingNumber(){
		int result = 0;
		for (int i = 0; i < _hoodsArray.Length; i++) {
			if (_hoodsArray [i])
				result++;
		}
		return result;
	}

	//投票メソッド
	public void Vote(int suffix, int opponent){
		_vote [suffix] = opponent;
	}

	//音を準備するメソッド
	public void LoadBgm(){
		if (_loadBgm == false) {
			//-----Bgm-----
			Sound.LoadBgm ("title", "NewTitle");
			Sound.LoadBgm ("overView", "Manual");
			Sound.LoadBgm ("manual", "Manual");
			Sound.LoadBgm ("themeCheck", "ThemeCheck");
			Sound.LoadBgm ("main", "Main");
			Sound.LoadBgm ("vote", "NewVote");
			Sound.LoadBgm ("drum", "Drum");
			//----Se----
			Sound.LoadSe ("next", "Button1");
			Sound.LoadSe ("back", "Button2");
			Sound.LoadSe ("drumAfter", "DrumAfter");
			Sound.LoadSe ("select", "Select");
		}
		_loadBgm = true;

	}

	//-----Debug用メソッド------
	public void DebugAttend(){
		for (int i = 0; i < _hoodsArray.Length; i++) {
			_hoodsArray [i] = true;
		}
	}

	public void CheckAttendents(){
		for (int i = 0; i < _hoodsArray.Length; i++) {
			Debug.Log (i + "番目のずきんちゃんは" + _hoodsArray [i]);
		}
	}

	public int MostVote(){
		int result = 0;
		int most = 0;
		bool draw = false;
		int[] voteNum = new int[6];

		//得票数計算
		for (int i = 0; i < voteNum.Length; i++) {
			if (_hoodsArray [i]) {
				voteNum [_vote [i]] += 1;
			}
		}

		//ずきんちゃんの得票数を比べる
		for (int i = 0; i < _vote.Length; i++) {
			//引き分けの場合は、引き明けフラグをオン
			if (voteNum [i] == most) {
				draw = true;
			}

			//得票数が最大だったら、登録し、引き分けフラグをオフにする。
			if (voteNum[i] > most) {
				most = voteNum[i];
				result = i;
				draw = false;
			}
		}

		//引き分けがあった場合、引き分け用の数字を出す。
		if (draw) {
			result = 100;
		}

		return result;
	}

}
