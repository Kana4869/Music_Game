using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    string _musicId;

    [Range(0, 1)]
    [SerializeField]
    int _difficulty;

    private bool _clicked = false;
    private string _userId; 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButton()
    {
        if (_clicked) // 二重選択されないようにする
        {
            return;
        }
        _clicked = true;
        _userId = "dummy_user"; // ひとまずユーザIDはダミー値で固定
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

}
