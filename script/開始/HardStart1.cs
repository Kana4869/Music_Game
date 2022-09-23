using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ボタンを使用する為に必要
using UnityEngine.UI;
//シーンを操作する為に必要
using UnityEngine.SceneManagement;

public class HardStart : MonoBehaviour

{
    // Start is called before the first frame update

    public void Start()

    {
        //ボタンが押された時、StartGame関数を実行
        //onClick.AddListener()メソッドでクリックされたら()内のメソッドを実行するイベントを設定
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }
    // Update is called once per frame

    void StartGame()
    {
        //GameSceneをロードする
        SceneManager.LoadScene("GameScene");

    }

}