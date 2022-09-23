using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //衝突したとき
    private void OnCollisionEnter(Collision collision)
    {
        //"Player"タグがついているオブジェクトに衝突した場合
        if (collision.gameObject.tag == "Miss")
        {

            //0.1秒後にオブジェクトが消える
            Destroy(gameObject, 0.1f);
        }
    }
}
