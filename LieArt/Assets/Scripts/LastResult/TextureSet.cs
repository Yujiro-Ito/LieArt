using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextureSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Texture2D texture = GameManager.GetInstance ().DrawResult;
		GetComponent<Image> ().sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), Vector2.zero);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
