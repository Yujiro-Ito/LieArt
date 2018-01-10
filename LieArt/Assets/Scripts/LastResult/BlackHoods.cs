using UnityEngine;
using System.Collections;

public class BlackHoods : MonoBehaviour {
	private int _state;
	// Use this for initialization
	void Start () {
		_state = GameManager.GetInstance ().GetVote [(int)GameManager.HoodsNumber.Black];
		switch (_state) {
		case (int)GameManager.HoodsNumber.Blue:
			transform.rotation = Quaternion.Euler (0, 0, -15);
			break;
		case (int)GameManager.HoodsNumber.Sky:
			transform.rotation = Quaternion.Euler (0, 0, -145);
			break;
		case (int)GameManager.HoodsNumber.White:
			transform.rotation = Quaternion.Euler (0, 0, -125);
			break;
		case (int)GameManager.HoodsNumber.Red:
			transform.rotation = Quaternion.Euler (0, 0, 0);
			break;
		case (int)GameManager.HoodsNumber.Pink:
			transform.rotation = Quaternion.Euler (0, 0, -30);
			break;
		}
	}
	
	
}
