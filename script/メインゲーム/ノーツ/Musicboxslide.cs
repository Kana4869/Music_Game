using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicboxslide : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {

        //musicbox�I�u�W�F�N�g�̃g�����X�t�H�[���̎擾
        Transform myTransform = this.transform;

        //���W�̎擾
        Vector3 pos = myTransform.position;

        
        //z�����̑��x
        pos.z -= 0.08f;

        //���W�̐ݒ�
        myTransform.position = pos;
        //�ēx���m���ď�L���J��Ԃ��H
    }
}
