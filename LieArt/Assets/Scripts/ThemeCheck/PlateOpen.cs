using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlateOpen : MonoBehaviour {

    private const int MAX_WIDTH = 600;
    private const int MIN_WIDTH = 0;
    private const int VIEW_WIDTH = 450; //テーマが表示され始めるXの値

    private const int defaultTapTextSize = 45;
    //private Vector2 defaultSheetSize;

    private RectTransform SheetSize;  //ゲームオブジェクト

    private GameObject SheetGO;
    //private RectTransform SheetRectTransform;
    private Text Sheet;
    private Text invisibleText;
    private Text currentPlayerName;

    private string invisibleTheme;
    private Color black;
    private Color red;
    private bool openSheet;
    private float secondCount;
    private int playerCount;
    private int _joinNumber;
    private GameObject _text;
    private int[] _joinText = new int[6];
    private int _count;
    private  GameObject _zukin;
    private GameObject _reZukin;

    //----ずきんちゃんたちの定数----//
    private const int RED = 0;
    private const int BLUE = 1;
    private const int WHITE = 2;
    private const int BLACK = 3;
    private const int PINK = 4;
    private const int SKY = 5;
    //--------------------------//

    private Vector2 sizeDeltaChange;
    private Text SheetText;
    private GameObject SheetTextGO;
    private RectTransform SheetTextSize;
    private Vector2 changeSizeX;
    private bool rotationHalfTurn;
    private bool rotationTurn;
    private bool charaMove;
    private Vector3 charaChangePosX = new Vector3(0.25f,0,0);

    //----------カウントダウンのテキスト関係----------
    private int fontSizeChange = 1;
    private GameObject promptTextGO; //「次の人は」のゲームオブジェクト
    private Text promptText;
    private GameObject countDownGO;  //カウントダウンのゲームオブジェクト
    private Text countDown;          //カウントダウンのテキスト
    //------------------------------------------------

    // Use this for initialization
    void Start () {
        rotationHalfTurn = false;
        rotationTurn = false;
        charaMove = true;
        changeSizeX = new Vector2(25,0);

        SheetTextGO = GameObject.Find("SheetText");
        SheetTextSize = SheetTextGO.GetComponent<RectTransform>();
        SheetText = SheetTextGO.GetComponent<Text>();
        sizeDeltaChange = new Vector2(1, 1);
        //defaultSheetSize = new Vector2(580,320);

        promptTextGO = GameObject.Find("PromptText");
        promptText = promptTextGO.GetComponent<Text>();
        countDownGO = GameObject.Find("PromptCountDown");
        countDown = countDownGO.GetComponent<Text>();
        countDown.text = "次の人まで";
        promptTextGO.SetActive(false);
        countDownGO.SetActive(false);

        black = new Color(0,0,0);
        red = new Color(255,0,0);
        _zukin = GameObject.FindWithTag("Zukin");
        _text  = GameObject.Find("NameText");
        secondCount = 0;
        SheetGO = GameObject.Find("Sheet");
        //SheetRectTransform = SheetGO.GetComponent<RectTransform>();
        Sheet = SheetGO.GetComponent<Text>();
        SheetSize = GameObject.Find("Sheet").GetComponent<RectTransform>();
        invisibleTheme = GameManager.GetInstance().InvisibleTheme;
        /*if (GameManager.GetInstance().UnknownPerson != 0) {
            SheetText.text = invisibleTheme;
        }*/
		playerCount = 0;
        _count = 0;
         for(int i = 0; i < GameManager.GetInstance().HoodsMember.Length; i++){
			if(GameManager.GetInstance().HoodsMember[i]){  //参加
				_joinNumber += 1;
                _joinText[_count] = i;
                _count += 1;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetAllScenes().Length == 1)
        {
            _text.GetComponent<NameText>().ChangeText(_joinText[playerCount]);
            PlayerInstance(_joinText[playerCount]);
            //NextPlayerCheck();
            if (charaMove) {
                CharaAppearance();
            } else {
                NextPlayerCheck();
            }
        }
	}

    public void Open() {
        if (SceneManager.GetAllScenes().Length == 1 && charaMove == false) {
            openSheet = true;
            //SheetGO.SetActive(false);
        }
    }

    void CharaAppearance() {
        if (playerCount >= 1) {
            if (_reZukin.transform.position.x != -15 && _reZukin != null) {
                _reZukin.transform.localScale = new Vector3(-2,2);
                _reZukin.transform.position -= charaChangePosX;
            }
        }
        if (_zukin.transform.position.x < -7) {
            _zukin.transform.position += charaChangePosX;
        } else if (_zukin.transform.position.x <= -7) {
            charaMove = false;
        }
    }

    void NextPlayerCheck() {
        if (openSheet) {
            if (SheetSize.sizeDelta.x > MIN_WIDTH && rotationHalfTurn == false) {
                SheetSize.sizeDelta -= changeSizeX;
                SheetTextSize.sizeDelta -= changeSizeX;
                SheetTextGO.SetActive(false);
            } else {
                if (SheetSize.sizeDelta.x <= MAX_WIDTH) {
                    rotationHalfTurn = true;
                    if (SheetSize.sizeDelta.x > VIEW_WIDTH) {
                        SheetTextGO.SetActive(true);
                        ViewTheme();
                    }
                    SheetSize.sizeDelta += changeSizeX;
                    SheetTextSize.sizeDelta += changeSizeX;
                    if (SheetSize.sizeDelta.x >= MAX_WIDTH) {
                        rotationTurn = true;
                        secondCount = 0;
                        countDownGO.SetActive(true);
                        promptTextGO.SetActive(true);
                        countDown.text = "";
                    }
                }
            }

            if (rotationTurn) {
                ViewTheme();
                secondCount += Time.deltaTime;
                if (playerCount != _joinNumber - 1) {  //最後の人か？
                    if (secondCount >= 1) countDown.text = 3 + "";
                    if (secondCount >= 2) countDown.text = 2 + "";
                    if (secondCount >= 3) countDown.text = 1 + "";
                    if (secondCount >= 4) countDown.text = 0 + "";
                } else {
                    countDown.text = "";
                    promptText.text = "テーマかくにん終了";
                }
                if (secondCount > 5) {
                    openSheet = false;
                    if (playerCount == _joinNumber - 1) {
                        SceneManager.LoadScene("Main");
                    } else {
                        rotationHalfTurn = false;
                        rotationTurn = false;
                        playerCount++;
                        charaMove = true;
                        _reZukin = _zukin;
                        SheetText.fontSize = defaultTapTextSize;
                    }
                }
            }

        } else {
            promptTextGO.SetActive(false);
            countDownGO.SetActive(false);
            SheetText.color = black;
            SheetText.text = "タップ";
            //-----------タップの文字、サイズ変更----------
            SheetText.fontSize += fontSizeChange;
            if (SheetText.fontSize < 45 || SheetText.fontSize > 60) {
                fontSizeChange *= -1;
            }
            //---------------------------------------------
            /*
            //-----------看板のサイズ変更------------------
            SheetRectTransform.sizeDelta += sizeDeltaChange;
            if (SheetRectTransform.sizeDelta.x < 580 && SheetRectTransform.sizeDelta.x > 595 || SheetRectTransform.sizeDelta.y < 320 || SheetRectTransform.sizeDelta.y > 335) {
                sizeDeltaChange *= -1;
            }
            //---------------------------------------------
            */
        }
    }

    void ViewTheme() {
        SheetText.fontSize = defaultTapTextSize;
        //SheetRectTransform.sizeDelta = defaultSheetSize;
        if (GameManager.GetInstance().UnknownPerson != playerCount) {
            SheetText.color = black;
            SheetText.text = invisibleTheme;
        } else {
            SheetText.color = red;
            SheetText.text = "あなたがウソズキンです";
        }
    }

    void PlayerInstance(int num){
        switch (num){
            case RED:
                /*
                if(_zukin != GameObject.Find("Red")){
                    _zukin.GetComponent<SpriteRenderer>().enabled = false;
                }
                */
                GameObject.Find("Red").GetComponent<SpriteRenderer>().enabled = true;
                _zukin = GameObject.Find("Red");
            break;

            case BLUE:
                /*
              if(_zukin != GameObject.Find("Blue")){
                    _zukin.GetComponent<SpriteRenderer>().enabled = false;
                 }
                 */
                GameObject.Find("Blue").GetComponent<SpriteRenderer>().enabled = true;
                _zukin = GameObject.Find("Blue");
                break;

            case WHITE:
                /*
                if(_zukin != GameObject.Find("White")){
                    _zukin.GetComponent<SpriteRenderer>().enabled = false;
                 }
                 */
                GameObject.Find("White").GetComponent<SpriteRenderer>().enabled = true;
                _zukin = GameObject.Find("White");
                break;

            case BLACK:
                /*
                if(_zukin != GameObject.Find("Black")){
                   _zukin.GetComponent<SpriteRenderer>().enabled = false;
                }
                */
                GameObject.Find("Black").GetComponent<SpriteRenderer>().enabled = true;
                _zukin = GameObject.Find("Black");
                break;

            case PINK:
                /*
               if(_zukin != GameObject.Find("Pink")){
                    _zukin.GetComponent<SpriteRenderer>().enabled = false;
               }
               */
                GameObject.Find("Pink").GetComponent<SpriteRenderer>().enabled = true;
                _zukin = GameObject.Find("Pink");
                break;

            case SKY:
                /*
                if(_zukin != GameObject.Find("Sky")){        
                    _zukin.GetComponent<SpriteRenderer>().enabled = false;
                }
                */
                GameObject.Find("Sky").GetComponent<SpriteRenderer>().enabled = true;
                _zukin = GameObject.Find("Sky");
                break;

            default:
            break;
        }
    }

}
