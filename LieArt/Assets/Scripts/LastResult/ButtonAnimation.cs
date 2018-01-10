using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour {
	private float _second;
	private bool _switch;
	public const float MAX_SEC = 0.25f;
	public const float ADD_SCALE = 0.01f;

	// Use this for initialization
	void Start () {
		_second = 0f;
		_switch = false;
	}
	
	// Update is called once per frame
	void Update () {
		//秒数計算
		_second += Time.deltaTime;
		if (_second >= MAX_SEC) {
			_second = 0;
			_switch = !_switch;
		}

		//ボタンの大小
		Vector3 scaleSize = transform.localScale;
		if (_switch) {
			scaleSize += new Vector3 (ADD_SCALE, ADD_SCALE, 0);
		} else {
			scaleSize -= new Vector3 (ADD_SCALE, ADD_SCALE, 0);
		}
		transform.localScale = scaleSize;
	}


}
