using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PushZukin : MonoBehaviour {
	public GameObject[] _zukin;
	public GameObject[] _buttons;
    private Color changeAnpha;
	private int _number;

	private Vector3 NORMAL_SIZE = new Vector3(1.5f, 1.5f);
	private Vector3 BIG_SIZE = new Vector3(2.0f, 2.0f);

	// Use this for initialization
	void Start () {
        changeAnpha = new Color(0,0,0,0.5f);
        for (int i = 0; i < 6; i++) {
            _zukin[i].GetComponent<SpriteRenderer>().color -= changeAnpha;
        }

		Sound.PlayBgm ("overView");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pushButton(int number){
		_number = number;
		if(GameManager.GetInstance().HoodsMember[_number]){  //参加の場合は不参加にする
			_zukin[_number].transform.localScale = NORMAL_SIZE;
			GameManager.GetInstance().HoodsMember[_number] = false;
            _zukin[_number].GetComponent<SpriteRenderer>().color -= changeAnpha;
		}else{  //不参加の場合は参加にする
			_zukin[_number].transform.localScale = BIG_SIZE;
			GameManager.GetInstance().HoodsMember[_number] = true;
            _zukin[_number].GetComponent<SpriteRenderer>().color += changeAnpha;
        }
    }
}
