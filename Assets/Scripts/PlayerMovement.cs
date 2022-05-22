using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //在 Unity中3D空間由三個坐標表示數據類型稱為Vector3 。
    Vector3 m_Movement;

    Animator m_Animator;
    // Start is called before the first frame update
    //void 為返回類型
    //void Start 此語法用在開始遊戲只執行一次
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update 此語法用在遊戲中需要不斷重複執行的事件
    void Update()
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

    }
}
