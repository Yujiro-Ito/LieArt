using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UniPainter : MonoBehaviour
{
    private Color changeAlpha = new Color(0, 0, 0, 255f);

    private GameObject Canvas;
    public string sceneName;
    public GameObject EndText;
    public GameObject NextText;
    public GameObject NextTextBG;
    public GameObject TransitionButton;
    private Text nextText;

    private int countMemory;    //カウントを記憶する

    Texture2D texture;
    string color_str = "000000";

    private int screenWidth;
    private int screenHeight;
	private Text _turnText;

    private int playerMax; //playerの人数
    public int playerCount; //何人目が書いているかのカウント

    private float frameCount;
    //private int secondCount;

    private bool paintEnd;      //今の一人終了
    private bool paintFinalEnd; //全員終了
    private bool paintNext;

    private NameTheme_View ViewSC;
    private GameObject UImanager;
	private int _maxTurn;
	private int _nowTurn;

    void Awake()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
		_maxTurn = GameManager.GetInstance ().Turn;
		//Debug.Log ("ターン" + GameManager.GetInstance ().Turn);
		_nowTurn = 1;
		_turnText = GameObject.Find ("Canvas/Turn").gameObject.GetComponent<Text> ();
        //_turnText.text = "" + _nowTurn + "周目";
        _turnText.text = "" + _nowTurn + " / " + _maxTurn + "周目";
    }

    void Start()
    {
        countMemory = 0;
        paintEnd = false;
        paintFinalEnd = false;
        frameCount = 0;
        playerCount = 0;
        Canvas = GameObject.Find("Canvas");
        UImanager = GameObject.Find("UImanager");
        texture = GetComponent<GUITexture>().texture as Texture2D;
        if (texture == null) {
            texture = new Texture2D(screenWidth, screenHeight);
            this.GetComponent<GUITexture>().pixelInset = new Rect(screenWidth - screenWidth / 2, screenHeight - screenHeight / 2, 0, 0);
            GetComponent<GUITexture>().texture = texture;
        }

        //---------参加人数のカウント--------
        for (int i = 0; i < GameManager.GetInstance().HoodsMember.Length; i++) {
            if (GameManager.GetInstance().HoodsMember[i] == true) {
                playerMax++;
            }
        }
        //-----------------------------------
        NextTextBG.SetActive(true);
        nextText = GameObject.Find("NextText").GetComponent<Text>();
        EndText.SetActive(false);
        //NextText.SetActive(false);
        paintNext = true;
        PlayerManager.randAfterParticipation[playerCount].GetComponent<Image>().color += changeAlpha;
    }
    /*
    void OnGUI()
    {
        color_str = GUI.TextField(new Rect(0, 0, 100, 20), color_str);
    }
    */

    bool write = false;
    Vector2 beforeMousePos;
    private int countDown = 5;
    void Update()
    {
        if (SceneManager.GetAllScenes().Length == 1) {
            //===========次の人へ促す処理====================
            if (paintNext && paintFinalEnd == false) {
                nextText.text = "開始まであと" + countDown;
                frameCount += Time.deltaTime;
                if (frameCount >= 1)countDown = 4;
                if (frameCount >= 2)countDown = 3;
                if (frameCount >= 3)countDown = 2;
                if (frameCount >= 4)countDown = 1;
                write = false;
                if (frameCount >= 5) {
                    nextText.text = "";
                    paintNext = false;
                    paintEnd = false;
                    NextTextBG.SetActive(false);
                    frameCount = 0;
                    countDown = 5;
                }
            }
            //=================================================

            //===========全員書き終わったときの処理==========
            if (paintFinalEnd) {
                //frameCount += Time.deltaTime;
                TransitionButton.SetActive(true);
                EndText.SetActive(true);
                Canvas.SetActive(false);
                /*if (frameCount >= 2) {    //3秒(180frame)たったら
                    EndText.SetActive(true);
                }
                if (frameCount >= 5) {
                    SceneManager.LoadScene("Vote");
                }
                */
            }
            //===============================================

            if (write)
            {
                Vector2 v = Input.mousePosition;
                lineTo(beforeMousePos, v, getColor());
                beforeMousePos = v;
                texture.Apply();
            }
        }
    }

    public Color getColor()
    {
        try
        {
            float r = Convert.ToInt32(color_str.Substring(0, 2), 16);
            float g = Convert.ToInt32(color_str.Substring(2, 2), 16);
            float b = Convert.ToInt32(color_str.Substring(4, 2), 16);
            return new Color(r, g, b);
        }
        catch (Exception e)
        {
            return Color.black;
        }
    }

    //==================textureに絵を描く処理=====================
    public void lineTo(Vector2 start, Vector2 end, Color color)
    {
        float x = start.x, y = start.y;
        // color of pixels
        Color[] wcolor = { color };

        if (Mathf.Abs(start.x - end.x) >= Mathf.Abs(start.y - end.y)) {
            float dy = end.x == start.x ? 0 : (end.y - start.y) / (end.x - start.x);
            float dx = start.x < end.x ? 1 : -1;
            //draw line loop
            while (x >= 0 && x < texture.width && y >= 0 && y < texture.height) {
                try
                {
					for(int i = (int)x - 3; i <= (int)x + 3; i++){
						for(int j = (int)y - 3; j <= (int)y + 3; j++){
							texture.SetPixels(i, j, 1, 1, wcolor);
						}
					}
                    x += dx;
                    y += dx * dy;
                    if (start.x <= end.x && x >= end.x ||
                            start.x >= end.x && x <= end.x) {
                        break;
                    }
                }
                catch (Exception e)
                {
                    //Debug.LogException(e);
                    break;
                }
            }
        } else if (Mathf.Abs(start.x - end.x) < Mathf.Abs(start.y - end.y)) {
            float dx = start.y == end.y ? 0 : (end.x - start.x) / (end.y - start.y);
            float dy = start.y < end.y ? 1 : -1;
            while (x >= 0 && x < texture.width && y >= 0 && y < texture.height) {
                try
                {
					for(int i = (int)x - 3; i <= (int)x + 3; i++){
						for(int j = (int)y - 3; j <= (int)y + 3; j++){
							texture.SetPixels(i, j, 1, 1, wcolor);
						}
					}
                    x += dx * dy;
                    y += dy;
                    if (start.y <= end.y && y >= end.y ||
                            start.y >= end.y && y <= end.y) {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    break;
                }
            }
        }
    }
    //============================================================

    void OnMouseDown() {
        if (SceneManager.GetAllScenes().Length == 1 && paintNext == false) {
            playerCount++;
            if (playerCount <= playerMax && paintEnd == false)
            {
                write = true;
            }
            beforeMousePos = Input.mousePosition;
        }
    }

    void OnMouseUp() {
        if (SceneManager.GetAllScenes().Length == 1 && paintNext ==false)
        {
            paintNext = true;
            paintEnd = true;
            NextTextBG.SetActive(true);
            if (playerCount != 0 && countMemory != playerCount) {
                PlayerManager.randAfterParticipation[playerCount - 1].GetComponent<Image>().color -= changeAlpha;
            } else if(countMemory == playerCount) {
                return;
            }
            if (playerCount >= PlayerManager.randAfterParticipation.Length) {
                PlayerManager.randAfterParticipation[0].GetComponent<Image>().color += changeAlpha;
            } else {
                    PlayerManager.randAfterParticipation[playerCount].GetComponent<Image>().color += changeAlpha;
            }
            if (playerCount == playerMax) {
                if (_nowTurn != _maxTurn) {
                    playerCount = 0;
                    _nowTurn++;
                    _turnText.text = "" + _nowTurn + " / " + _maxTurn + "周目";
                    paintNext = true;
                } else {
                    NextTextBG.SetActive(false);
                    paintFinalEnd = true;
					GameManager.GetInstance ().DrawResult = texture;
                }
            }
            write = false;
            countMemory = playerCount;
        }
    }
}