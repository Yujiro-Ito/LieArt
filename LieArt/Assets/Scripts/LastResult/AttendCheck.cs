using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttendCheck : MonoBehaviour {
	private SpriteRenderer spRenderer;
	private SpriteRenderer wolfzukin;
	public GameObject[] hoodsSprites;
	public GameObject[] rods;
    public GameObject[] wolfs;
	private int nmbr;
	int i;
	// Use this for initialization
	void Start () {
		spRenderer = GetComponent<SpriteRenderer> ();
		for( i = 0; i < 6; i++ ){
			//ずきんちゃん出欠確認
			bool attend = GameManager.GetInstance ().HoodsMember [i];
			//出席しているずきんちゃんのスプライトをとってくる
			spRenderer = hoodsSprites [i].GetComponent<SpriteRenderer> ();
			//オオカミのスプライトをとってくる
			wolfzukin = wolfs[i].GetComponent<SpriteRenderer>();
			//オオカミずきんを消す
			wolfs[i].SetActive(false);
			//指し棒を消す
			if (attend == false) {
				//色を変える
				float alpha = 0.3f;
				var color = spRenderer.color;
				color.a = alpha;
				spRenderer.color = color;

				rods [i].SetActive (false);
			} 
		  }
		  StartCoroutine ("TestCoroutine");
	  }

	public IEnumerator TestCoroutine(){
		yield return new WaitForSeconds (7f);
		for (i = 0; i < 6; i++) {
			//ずきんちゃん出欠確認
			bool attend = GameManager.GetInstance ().HoodsMember [i];
			if ( attend == true ) {
				rods [i].SetActive (true);
			}
		}
		//オオカミずきんの確認
		int wlofattend = GameManager.GetInstance().UnknownSuffix;
		hoodsSprites [wlofattend].SetActive (false);
		wolfs [wlofattend].SetActive (true);
		rods [wlofattend].SetActive (true);
		GameObject.Find("Canvas/Panel/ThemeText").GetComponent<Text>().text = GameManager.GetInstance().InvisibleTheme;
		//投票数の多いずきんちゃんの確認
		nmbr = GameManager.GetInstance ().MostVote();
		//yield return new WaitForSeconds (2f);
		yield return new WaitForSeconds (3f);
	}
}
