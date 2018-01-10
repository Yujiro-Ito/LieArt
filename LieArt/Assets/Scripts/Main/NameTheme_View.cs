using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameTheme_View : MonoBehaviour
{
    private GameObject Painter;
    private UniPainter uniPainter;

    private Text visibleTheme;
    private string visibleText;
    private Text playerName;
    private string nameText;
    private int playerCount;
    // Use this for initialization
    void Start()
    {
        Painter = GameObject.Find("PaintingCanvas");
        uniPainter = Painter.GetComponent<UniPainter>();
        ThemeView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ThemeView() {
        visibleTheme = GameObject.Find("VisibleTheme").gameObject.GetComponent<Text>();
        visibleText = GameManager.GetInstance().VisibleTheme;
        visibleTheme.text = visibleText;
    }
}
