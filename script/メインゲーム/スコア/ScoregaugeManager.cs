using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoregaugeManager : MonoBehaviour
{
    //�X���C�_�[���i�[����
    public Slider scoregauge;

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g����scoregauge�����o����
        scoregauge = GameObject.Find("scoregauge").GetComponent<Slider>();
        //0����X�^�[�g����
        scoregauge.value = 0;
    }

    //�Փ˂�����
    private void OnCollisionEnter(Collision collision)
    {
        //"Player"�^�O�̃I�u�W�F�N�g�ɏՓ˂����ꍇ
        if (collision.gameObject.tag == "Player")
        {
            //0.008��������
            scoregauge.value += 0.008f;
        }
    }

}