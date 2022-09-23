using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicboxslide : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {

        //musicboxオブジェクトのトランスフォームの取得
        Transform myTransform = this.transform;

        //座標の取得
        Vector3 pos = myTransform.position;

        
        //z方向の速度
        pos.z -= 0.08f;

        //座標の設定
        myTransform.position = pos;
        //再度検知して上記を繰り返す？
    }
}
