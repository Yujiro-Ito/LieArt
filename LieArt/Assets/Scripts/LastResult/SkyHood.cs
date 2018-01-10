using UnityEngine;
using System.Collections;

public class SkyHood : MonoBehaviour {
	private int _state;
	// Use this for initialization
	void Start () {
		_state = GameManager.GetInstance ().GetVote [(int)GameManager.HoodsNumber.Sky];
		switch(_state){
		case (int)GameManager.HoodsNumber.Blue:
			transform.rotation = Quaternion.Euler (0, 0, 5);
			break;
		case (int)GameManager.HoodsNumber.White:
			transform.rotation = Quaternion.Euler (0, 0, -110);
			break;
		case (int)GameManager.HoodsNumber.Black:
			transform.rotation = Quaternion.Euler (0, 0, 35);
			break;
		case (int)GameManager.HoodsNumber.Red:
			transform.rotation = Quaternion.Euler (0, 0, 18);
			break;
		case (int)GameManager.HoodsNumber.Pink:
			transform.rotation = Quaternion.Euler (0, 0, -15);
			break;
		}
	}
}
