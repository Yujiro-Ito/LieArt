using UnityEngine;
using System.Collections;

public class RedHoods : MonoBehaviour {
	private int _state;

	// Use this for initialization
	void Start () {
		_state = GameManager.GetInstance ().GetVote [(int)GameManager.HoodsNumber.Red];
		switch(_state){
		case (int)GameManager.HoodsNumber.Blue:
			transform.rotation = Quaternion.Euler (0, 0, 150);
			break;
		case (int)GameManager.HoodsNumber.White:
			transform.rotation = Quaternion.Euler (0, 0, 30);
			break;
		case (int)GameManager.HoodsNumber.Black:
			transform.rotation = Quaternion.Euler (0, 0, 0);
			break;
		case (int)GameManager.HoodsNumber.Pink:
			transform.rotation = Quaternion.Euler (0, 0, 130);
			break;
		case (int)GameManager.HoodsNumber.Sky:
			transform.rotation = Quaternion.Euler (0, 0, 10);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
