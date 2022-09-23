using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoretext : MonoBehaviour
{
    //スコア加算したいtextと紐付ける
    public static float Score;
    public TextMeshProUGUI scorecounttext;

    //Scoretextにアクセスして実行する
    internal static void SetScoretext()
    {
        throw new NotImplementedException();
    }

    public static int getscore()
    
    {
        return (int)Score;
    }

    // Start is called before the first frame update
    void Start()
    {
        //0からスタートする
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //textのフォーマットを設定する
        scorecounttext.text = string.Format("{0}", Score);

        if (Score < 0)
        {
            Score = 0;
        }
    }
}