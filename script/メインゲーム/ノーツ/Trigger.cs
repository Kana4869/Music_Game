using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public void PointerDown()
    {
        //ボタンを押すとオブジェクトが表示される
        //(ノーツがたたかれる)
        this.gameObject.SetActive(true);
    }

    public void PointerUp()
    {
        //ボタンを離すと非アクティブになる
        this.gameObject.SetActive(false);
    }
}