using UnityEngine;
using System.Collections;

public class WhiteHood : MonoBehaviour {
	private int _state;
	// Use this for initialization
	void Start () {
		_state = GameManager.GetInstance ().GetVote [(int)GameManager.HoodsNumber.White];
		switch(_state){
		case (int)GameManager.HoodsNumber.Blue:
			transform.rotation = Quaternion.Euler (0, 0, 25);
			break;
		case (int)GameManager.HoodsNumber.Sky:
			transform.rotation = Quaternion.Euler (0, 0, 90);
			break;
		case (int)GameManager.HoodsNumber.Black:
			transform.rotation = Quaternion.Euler (0, 0, 50);
			break;
		case (int)GameManager.HoodsNumber.Red:
			transform.rotation = Quaternion.Euler (0, 0, 35);
			break;
		case (int)GameManager.HoodsNumber.Pink:
			transform.rotation = Quaternion.Euler (0, 0, 0);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
