﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//usingはシーン遷移に必要なパッケージ
using UnityEngine.SceneManagement;

public class Tips1 : MonoBehaviour
{
    //inspectorで「sceneName」は設定
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
        //inspectorで「sceneName」は設定
        SceneManager.LoadScene(sceneName);
    }
}

