using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public void PointerDown()
    {
        //�{�^���������ƃI�u�W�F�N�g���\�������
        //(�m�[�c�����������)
        this.gameObject.SetActive(true);
    }

    public void PointerUp()
    {
        //�{�^���𗣂��Ɣ�A�N�e�B�u�ɂȂ�
        this.gameObject.SetActive(false);
    }
}