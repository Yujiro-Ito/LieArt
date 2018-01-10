using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Illumination : MonoBehaviour {
	public const float EASING = 0.3f;
	private int _state;
	private float _speedX = 0.05f;
	private float _speedY = 0.05f;
	private float SPEEDX = 0.05f;
	private float SPEEDY = 0.05f;
	private float ADD_SPEED = 0.003f;
	private float _color = 0.01f;
	private float alpha = 0.7f;
	bool _yplus = true;
	bool _flag = true;
	bool _lit = false;
	private SpriteRenderer spRenderer;
	private SpriteRenderer renderer;
	public GameObject[] hoodsSprites;
	public GameObject light;
	private int nmbr;
	private bool _move = false;
	public GameObject _syu;
	public GameObject _ryo;
	public GameObject _titleButton;

	//--new Move Method----
	public const int DECIDE = 0;
	public const int MOVE = 1;
	private int _moveState = DECIDE;

	public const float SLOW_EASING = 0.1f;
	private Vector3 _nextTarget = Vector3.zero;
	// Use this for initialization
	void Start () {
		//投票数の多いずきんちゃんの確認
		nmbr = GameManager.GetInstance ().UnknownSuffix;
		Sound.PlayBgm ("drum");
		//照明のスプライトをとってくる
		renderer = light.GetComponent<SpriteRenderer>();
		StartCoroutine ("TestCoroutine");
		_syu.SetActive (false);
		_ryo.SetActive (false);
		_titleButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (_flag == true) {
			/*transform.position += new Vector3 (_speedX, _speedY, 0.0f);
			//---上方向へ移動
			if (_yplus == true) {
				if (_speedY <= SPEEDY) {
					_speedY += ADD_SPEED;
				}
				if (transform.position.y >= 2.8f) {
					_yplus = false;
					SPEEDY = Random.Range (0.05f, 0.1f);
				}
			}

			//---下方向へ移動
			if (_yplus == false) {
				if (_speedY >= -SPEEDY) {
					_speedY -= ADD_SPEED;
				}

				if (transform.position.y <= -2.8f) {
					_yplus = true;
					SPEEDY = Random.Range (0.05f, 0.1f);
				}
			}

			//---横方向に移動
			if (transform.position.x >= 7.1 || transform.position.x <= -7.1f) {
				_speedX *= -1;
			}*/

			switch (_moveState) {
			case DECIDE:
				int suffix = Random.Range (0, hoodsSprites.Length);
				_nextTarget = hoodsSprites [suffix].transform.position;
				if (GameManager.GetInstance ().HoodsMember[suffix]) {
					_moveState = MOVE;
				}
				break;
			case MOVE:
				Vector3 diff = _nextTarget - transform.position;
				Vector3 v = diff * SLOW_EASING;

				transform.position += v;
				if (diff.magnitude <= 0.01f) {
					_moveState = DECIDE;
				}
				break;
			}
		}
		if( _lit == true ){
			//色を変える
		    alpha -= _color;
			var color = renderer.color;
			color.a = alpha;
			renderer.color = color;
		}

		if (_move) {
			Vector3 zukinPos = hoodsSprites [nmbr].transform.position;
			Vector3 diff = zukinPos - transform.position;
			Vector3 v = diff * EASING;

			transform.position += v;
			if (diff.magnitude <= 0.01f) {
				_lit = true;
			}
		}
	  }

	public IEnumerator TestCoroutine(){
		yield return new WaitForSeconds (7f);
		Vector3 zukinPos = hoodsSprites [nmbr].transform.position;
		Sound.StopBgm ();
		Sound.PlaySe ("drumAfter");
		//transform.position = new Vector3 ( zukinPos.x, zukinPos.y, 0.0f );
		_move = true;
		_flag = false;
		yield return new WaitForSeconds (2f);
		_syu.SetActive (true);
		_ryo.SetActive (true);
		_titleButton.SetActive (true);
		Sound.PlaySe ("drumAfter");
		//_lit = true;
	}

	public IEnumerator Coroutine(){
		yield return new WaitForSeconds (7f);
		Sound.StopBgm ();
		Sound.PlaySe ("drumAfter");
		transform.position = new Vector3 ( 0.0f, 0.0f, 0.0f );
		_flag = false;
		yield return new WaitForSeconds (2f);
		Sound.PlaySe ("drumAfter");
		_lit = true;
	}
}
