using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //在 Unity中3D空間由三個坐標表示數據類型稱為Vector3 。
    Vector3 m_Movement;

    Animator m_Animator;

    public float turnSpeed = 20f;

    Quaternion m_Rotation = Quaternion.identity;

    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    //void 為返回類型
    //void Start 此語法用在開始遊戲只執行一次
    void Start()
    {
        //這行代碼使用了一些熟悉的和一些新的語法：
        // 1.您分配給的變量的動點在左側。
        // 2.方法的名稱在右邊（但它前面沒有寫任何東西）。
        // 3.在您之前沒遇到的括號，Animator 周圍使用尖角括號 <>。
        // 4.該行以分號結束。

        m_Animator = GetComponent<Animator>();

        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //void Update 此語法用在遊戲中需要不斷重複執行的事件
    void FixedUpdate()
    {
        /*這行代碼中有幾條重要的語法結構*/
        // 1.在 C# 中等號意味著將右側的任何內容（方法的結果）分配給左側的變量（新創建的浮動變量）。  
        // 2.Input 和 GetAxis 之間的點號允許計算機訪問前一個對像中的某些內容（GetAxis 是 Input 中的一個方法，因此從 Input 到 GetAxis 使用點號）。  
        // 3.分號標誌著語句的結束，因此它的作用就像句尾的句號一樣。

        //創建一個新的浮動 水平 等於 輸入.取得軸("水平")
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);

        /*1.這段代碼創建了一個名為desiredForward的 Vector3 變量。
          2.它將它設置為一個名為RotateTowards的方法的返回值，該方法是 Vector3 類中的一個靜態方法。RotateTowards 有四個參數——前兩個是 Vector3，分別是被旋轉的向量。
          3.代碼以transform.forward開頭，並針對m_Movement變量。transform.forward 是訪問 Transform 組件並獲取其前向向量的快捷方式。
          4.接下來的兩個參數是起始向量和目標向量之間的變化量：首先是角度的變化（以弧度為單位），然後是幅度的變化。
            此代碼通過turnSpeed* Time.deltaTime更改角度，將幅度更改為 0。
        */

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    //void OnAnimatorMove 此方法允許您根據需要應用根運動，這意味著可以單獨應用移動和旋轉。
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

}
