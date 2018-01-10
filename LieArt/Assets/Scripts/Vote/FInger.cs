using UnityEngine;
using System.Collections;

public class FInger : MonoBehaviour {
	private const float ROTATE_SPEED = 10;
	private int _counter;
	private bool _finish = false;

	// Use this for initialization
	void Start () {
		_counter = 0;
		InVisible ();
	}
	
	// Update is called once per frame
	void Update () {
		/*_counter += 2;
		Quaternion localRot = transform.localRotation;
		localRot.y = _counter;
		transform.localRotation = localRot;
		Quaternion rot = transform.rotation;
		rot.z += -35;
		transform.rotation = rot;*/
		transform.Rotate (0, 2.6f, 0);
	}

	public void AssignPos(float pos){
		if (_finish == false) {
			GetComponent<SpriteRenderer> ().enabled = true;
			transform.position = new Vector3 (pos , 0.8f, 0);
		}
	}

	public void Finish(){
		_finish = true;
	}

	public void InVisible(){
		GetComponent<SpriteRenderer> ().enabled = false;
	}
}
