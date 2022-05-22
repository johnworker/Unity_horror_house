using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //�b Unity��3D�Ŷ��ѤT�ӧ��Ъ�ܼƾ������٬�Vector3 �C
    Vector3 m_Movement;

    Animator m_Animator;
    // Start is called before the first frame update
    //void ����^����
    //void Start ���y�k�Φb�}�l�C���u����@��
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update ���y�k�Φb�C�����ݭn���_���ư��檺�ƥ�
    void Update()
    {
        /*�o��N�X�����X�����n���y�k���c*/
        // 1.�b C# �������N���۱N�k�������󤺮e�]��k�����G�^���t���������ܶq�]�s�Ыت��B���ܶq�^�C  
        // 2.Input �M GetAxis �������I�����\�p����X�ݫe�@�ӹﹳ�����Y�Ǥ��e�]GetAxis �O Input �����@�Ӥ�k�A�]���q Input �� GetAxis �ϥ��I���^�C  
        // 3.�����лx�ۻy�y�������A�]�������@�δN���y�����y���@�ˡC

        //�Ыؤ@�ӷs���B�� ���� ���� ��J.���o�b("����")
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

    }
}
