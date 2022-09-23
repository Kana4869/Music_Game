using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//usingはシーン遷移に必要なパッケージ
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    private string _userId;
    private string _musicId;
    private int _difficulty;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadScene()
    {
        StartCoroutine(CoOnStartButton());
    }

    IEnumerator CoOnStartButton()
    {
        SceneManager.sceneLoaded += LoadCompleted;

        AsyncOperation async;

        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("GameScene");

        while (!async.isDone)
        {
            yield return null;
        }
    }

    private void LoadCompleted(Scene next, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadCompleted;

        Changescene mainGame = FindObjectOfType<Changescene>();
        mainGame.Setup(_userId, _musicId, _difficulty);

    }

    public void Setup(string userId, string musicId, int difficulty)
    {
        _userId = userId;
        _musicId = musicId;
        _difficulty = difficulty;

    }
}