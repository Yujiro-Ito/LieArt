using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Thema : MonoBehaviour {
	private string [,]stageMapDatas = null;

	private int height = 5;    //行数
	private int width  = 20;   //列数
	private int randomThema;   //共通のテーマのランダム変数
	private int randomSecretThema;  //秘密のテーマのランダム変数

	private string[,] readCSVData(string path){
	randomThema  = UnityEngine.Random.Range(0, height);  //共通のテーマ
	randomSecretThema = UnityEngine.Random.Range(1, width);  //秘密のテーマ
    //返り値の２次元配列
    string[,] readToIntData;

	var sr = Resources.Load("Csv/Thema");
    //ストリームリーダーをstringに変換
    string strStream = sr.ToString();

    //StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
    System.StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

    //行に分ける
    string []lines = strStream.Split(new char[]{'\r','\n'},option);

    //カンマ分けの準備(区分けする文字を設定する)
    char []spliter = new char[1]{','};

    //行数設定
    int heightLength = lines.Length;
    //列数設定
    int widthLength = lines[0].Split(spliter, option).Length;

    //返り値の2次元配列の要素数を設定
    readToIntData = new string[heightLength, widthLength];

    //カンマ分けをしてデータを完全分割
    for (int i = 0; i < heightLength; i++)
    {
        for (int j = 0; j < widthLength; j++)
        {
            //カンマ分け
            string [ ] readStrData = lines[i].Split(spliter, option);
            //型変換
            readToIntData[i, j] = readStrData[j];
        }
    }

    //確認表示用の変数(行数、列数)を格納する
    this.height = heightLength;    //行数
    this.width  = widthLength;     //列数

    //返り値
    return readToIntData;
}


	//確認表示用の関数
	//引数：2次元配列データ,行数,列数
	private void WriteMapDatas(string[,]arrays,int hgt ,int wid){
		GameManager.GetInstance().VisibleTheme = arrays[randomThema, 0];  //共通のテーマを決める
		GameManager.GetInstance().InvisibleTheme = arrays[randomThema, randomSecretThema];  //秘密のテーマを決める
	}

	// Use this for initialization
	void Start () {
		//データパスを設定
    	 //このデータパスは、Assetフォルダ以下の位置を書くので/で階層を区切り、CSVデータ名まで書かないと読み込んでくれない
     	string path    =   "/Resources/Csv/Thema.csv";
     	//データを読み込む(引数：データパス)
     	 this.stageMapDatas   = readCSVData(path); 

     	WriteMapDatas(this.stageMapDatas,this.height,this.width); 


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
