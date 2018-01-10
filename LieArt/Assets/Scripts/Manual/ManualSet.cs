using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManualSet : MonoBehaviour {

    private string currentSceneName;
    private GameObject currentManual;

    // Use this for initialization
    void Start() {

    }

    void Awake() {
        Text HeadingText = GameObject.Find("HeadingText").GetComponent<Text>();
        Text ContentText = GameObject.Find("ContentText").GetComponent<Text>();
        GameObject ManualPanel = GameObject.Find("Canvas/ManualPanel");
        Text cautionText = GameObject.Find("CautionText").GetComponent<Text>();
        string cautionSoro = "一人で見る画面です";
        string cautionEveryone = "みんなで見る画面です";
        Text turnText = GameObject.Find("TurnText").GetComponent<Text>();
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "PlayerSelect") {
            HeadingText.text = "プレイヤー選たく";
            ContentText.text = "ずきんちゃんをタップして３人以上選んでね！";
            
            cautionText.text = cautionEveryone;
        } else if (currentSceneName == "ThemeCheck") {
            HeadingText.text = "テーマかくにん";
            ContentText.text = "タップしてテーマをかくにんしてね。";
                        
            cautionText.text = cautionSoro;
        } else if (currentSceneName == "Main") {
            HeadingText.text = "お絵かき";
            ContentText.text = "一筆ずつかいて絵を完成させよう！";

            turnText.text = "周回数は" + GameManager.GetInstance().Turn + "周です。";
            cautionText.text = cautionEveryone;
        } else if (currentSceneName == "Vote") {
            HeadingText.text = "投票";
            ContentText.text = "怪しいと思うずきんちゃんに投票しよう！";

            cautionText.text = cautionSoro;
        } else if (currentSceneName == "Result") {
            HeadingText.text = "";
            ContentText.text = "結果発表！";

            ManualPanel.GetComponent<Image>().color = new Color(0, 0, 0);
            cautionText.text = cautionEveryone;
        }
        //currentManual.transform.parent = ManualPanel.transform;
        //currentManual.transform.SetAsFirstSibling();
        if (turnText.text != "")turnText.transform.SetAsFirstSibling();
        //currentManual.transform.localScale = new Vector3(1, 1, 1);
        //currentManual.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        /*
        //====================現在のシーンにあったManualをセット======================
        GameObject ManualPanel = GameObject.Find("Canvas/ManualPanel");
        Text cautionText = GameObject.Find("CautionText").GetComponent<Text>();
        string cautionSoro = "一人で見る画面です";
        string cautionEveryone = "みんなで見る画面です";
        Text turnText = GameObject.Find("TurnText").GetComponent<Text>();
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "PlayerSelect") {
            GameObject Prefab = (GameObject)Resources.Load("Prefab/Manual/PlayerSelectImage");
            currentManual = (GameObject)Instantiate(Prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            currentManual.GetComponent<RectTransform>().sizeDelta = new Vector2(850, 155);
            cautionText.text = cautionEveryone;
        } else if (currentSceneName == "ThemeCheck") {
            GameObject Prefab = (GameObject)Resources.Load("Prefab/Manual/ThemeCheckImage");
            currentManual = (GameObject)Instantiate(Prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            currentManual.GetComponent<RectTransform>().sizeDelta = new Vector2(837, 152);
            cautionText.text = cautionSoro;
        } else if (currentSceneName == "Main") {
            GameObject Prefab = (GameObject)Resources.Load("Prefab/Manual/MainImage");
            currentManual = (GameObject)Instantiate(Prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            currentManual.GetComponent<RectTransform>().sizeDelta = new Vector2(837, 152);
            turnText.text = "周回数は" + GameManager.GetInstance().Turn+ "周です。";
            cautionText.text = cautionEveryone;
        } else if (currentSceneName == "Vote") {
            GameObject Prefab = (GameObject)Resources.Load("Prefab/Manual/VoteImage");
            currentManual = (GameObject)Instantiate(Prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            currentManual.GetComponent<RectTransform>().sizeDelta = new Vector2(837, 152);
            cautionText.text = cautionSoro;
        } else if (currentSceneName == "Result") {
            GameObject Prefab = (GameObject)Resources.Load("Prefab/Manual/ResultImage");
            currentManual = (GameObject)Instantiate(Prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            currentManual.GetComponent<RectTransform>().sizeDelta = new Vector2(838, 142);
            ManualPanel.GetComponent<Image>().color = new Color(0,0,0);
            cautionText.text = cautionEveryone;
        }
        currentManual.transform.parent = ManualPanel.transform;
        currentManual.transform.SetAsFirstSibling();
        if (turnText.text != "") {
            turnText.transform.SetAsFirstSibling();
        }
        currentManual.transform.localScale = new Vector3(1, 1, 1);
        currentManual.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        //==========================================================================
        */
    }
}
