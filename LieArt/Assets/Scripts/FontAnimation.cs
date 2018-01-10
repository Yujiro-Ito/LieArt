using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FontAnimation : MonoBehaviour
{

    private GameObject TitleText;
    private float interval = 1.0f;   // 点滅周期

    private bool invisible;

    private float secondCount;

    // Use this for initialization
    void Start()
    {
        TitleText = GameObject.Find("TitleText");
        secondCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        secondCount += Time.deltaTime;
        if (secondCount >= 0.7) {
            TextFlashing();
            secondCount = 0;
        }
    }

    // 点滅コルーチン
    private void TextFlashing()
    {
        if (invisible)
        {
            this.GetComponent<Text>().color = new Color(0, 0, 0, 0);
            invisible = false;
        }
        else
        {
            this.GetComponent<Text>().color = new Color(0, 0, 0, 255);
            invisible = true;
        }
    }
}