using UnityEngine;
using System.Collections;

public class PinkHoods : MonoBehaviour {
	private int _state;
	// Use this for initialization
	void Start () {
		_state = GameManager.GetInstance ().GetVote [(int)GameManager.HoodsNumber.Pink];
		switch(_state){
		case (int)GameManager.HoodsNumber.Blue:
			transform.rotation = Quaternion.Euler (0, 0, -90);
			break;
		case (int)GameManager.HoodsNumber.White:
			transform.rotation = Quaternion.Euler (0, 0, 0);
			break;
		case (int)GameManager.HoodsNumber.Black:
			transform.rotation = Quaternion.Euler (0, 0, -35);
			break;
		case (int)GameManager.HoodsNumber.Red:
			transform.rotation = Quaternion.Euler (0, 0, -55);
			break;
		case (int)GameManager.HoodsNumber.Sky:
			transform.rotation = Quaternion.Euler (0, 0, -25);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
