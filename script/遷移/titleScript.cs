using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using�̓V�[���J�ڂɕK�v�ȃp�b�P�[�W
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour
{
    //inspector�ŁusceneName�v�͐ݒ�
    public string sceneName;

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
        //inspector�ŁusceneName�v�͐ݒ�
        SceneManager.LoadScene(sceneName);
    }
}

