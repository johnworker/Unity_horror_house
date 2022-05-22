using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //�b Unity��3D�Ŷ��ѤT�ӧ��Ъ�ܼƾ������٬�Vector3 �C
    Vector3 m_Movement;

    Animator m_Animator;

    public float turnSpeed = 20f;

    Quaternion m_Rotation = Quaternion.identity;

    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    //void ����^����
    //void Start ���y�k�Φb�}�l�C���u����@��
    void Start()
    {
        //�o��N�X�ϥΤF�@�Ǽ��x���M�@�Ƿs���y�k�G
        // 1.�z���t�����ܶq�����I�b�����C
        // 2.��k���W�٦b�k��]�����e���S���g����F��^�C
        // 3.�b�z���e�S�J�쪺�A���AAnimator �P��ϥΦy���A�� <>�C
        // 4.�Ӧ�H���������C

        m_Animator = GetComponent<Animator>();

        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //void Update ���y�k�Φb�C�����ݭn���_���ư��檺�ƥ�
    void FixedUpdate()
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

        m_Animator.SetBool("IsWalking", isWalking);

        /*1.�o�q�N�X�ЫؤF�@�ӦW��desiredForward�� Vector3 �ܶq�C
          2.���N���]�m���@�ӦW��RotateTowards����k����^�ȡA�Ӥ�k�O Vector3 �������@���R�A��k�CRotateTowards ���|�ӰѼơX�X�e��ӬO Vector3�A���O�O�Q���઺�V�q�C
          3.�N�X�Htransform.forward�}�Y�A�ðw��m_Movement�ܶq�Ctransform.forward �O�X�� Transform �ե�������e�V�V�q���ֱ��覡�C
          4.���U�Ӫ���ӰѼƬO�_�l�V�q�M�ؼЦV�q�������ܤƶq�G�����O���ת��ܤơ]�H���׬����^�A�M��O�T�ת��ܤơC
            ���N�X�q�LturnSpeed* Time.deltaTime��﨤�סA�N�T�ק�אּ 0�C
        */

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    //void OnAnimatorMove ����k���\�z�ھڻݭn���ήڹB�ʡA�o�N���ۥi�H��W���β��ʩM����C
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

}
