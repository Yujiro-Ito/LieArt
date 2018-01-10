using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThemaText : MonoBehaviour {

	private bool _themaOpen = false;  //テーマの表示を管理
	public bool ThemaOpen{ get{return _themaOpen;} set{_themaOpen = value;}}

	// Use this for initialization
	void Start () {
		this.GetComponent<Text>().text = GameManager.GetInstance().InvisibleTheme;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.SetActive(_themaOpen);
		Debug.Log(_themaOpen);
	}
}
