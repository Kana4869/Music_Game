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
    //�Փ˂����Ƃ�
    private void OnCollisionEnter(Collision collision)
    {
        //"Player"�^�O�����Ă���I�u�W�F�N�g�ɏՓ˂����ꍇ
        if (collision.gameObject.tag == "Miss")
        {

            //0.1�b��ɃI�u�W�F�N�g��������
            Destroy(gameObject, 0.1f);
        }
    }
}
