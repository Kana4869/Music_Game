using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// クラス名はリファクタリングして変更したほうが良いかも。。。
[RequireComponent(typeof(ResourceLoader))]
public class Changescene : MonoBehaviour

{
    [SerializeField]
    Retry _retry; 

    private bool _clicked = false;
    private string _userId;
    private string _musicId;
    private int _difficulty;
    private float _score;
    private float _quota; 

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame

    void ChangeScene()
    {
        if(_clicked) // 二重選択されないようにする
        {
            return; 
        }
        _clicked = true;
        StartCoroutine(CoChangeScene(Scoretext.Score));

    }

    IEnumerator CoChangeScene(float score)
    {
        _score = score; 
        SceneManager.sceneLoaded += LoadCompleted;

        AsyncOperation async;

        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("result");

        while (!async.isDone)
        {
            yield return null;
        }
    }

    private void LoadCompleted(Scene next, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadCompleted;

        ResultManager resultManager = FindObjectOfType<ResultManager>();
        resultManager.Setup(_userId, _musicId, _difficulty, _score, _quota);

    }

    internal void Setup(string userId, string musicId, int difficulty)
    {
        _userId = userId;
        _musicId = musicId;
        _difficulty = difficulty;
        _retry.Setup(userId, musicId, difficulty); 
        ResourceLoader resourceLoader = GetComponent<ResourceLoader>();
        resourceLoader.Setup(_musicId);
        _quota = resourceLoader.Quota; 

        //98秒後にChangeScene関数を実行する(本来は楽曲が終わった時点でシーン遷移すべきだが、一旦暫定対応とする)

        Invoke("ChangeScene", 98);
    }
}