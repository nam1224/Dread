using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float triggerRadius = 5f; //플레이어가 이동하면서 상호작용 가능한 물체르 탐지할 범위
    public LayerMask targetLayer; //플레이어가 탐지할 레이어는 Item

    private bool itemInRange = false;

    private void Start()
    {

    }

    private void Update()
    {
        Debug.Log("flashlight.energy : "+flashlight.energy);
        // 플레이어를 탐지하는 코드입니다.
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;

        // 플레이어가 범위에 처음 들어왔을 때 이벤트 발생 
        if (isPlayerInRange && !itemInRange)
        {
            itemInRange = true;
            Debug.Log("플레이어가 범위에 들어옴");
        }

        //플레이어가 범위에 계속 머무를 때
        else if (isPlayerInRange && itemInRange)
        {
            Debug.Log("플레이어가 범위에서 머무르는 중");
            //플레이어가 E키를 누른다면
            for (int i = 0; i < colliders.Length; i++)
                if (Input.GetKeyDown(KeyCode.E) && colliders[i].tag == "Bettery")
                {
                    //에너지를 충전함
                    Debug.Log("에너지 충전");
                }
        }

        // 플레이어가 범위를 벗어났을 때 플래그 업데이트
        else if (!isPlayerInRange && itemInRange)
        {
            itemInRange = false;
            Debug.Log("플레이어가 범위를 벗어남");
        }
    }


    Flashlight flashlight;
    //베터리 충전 함수
    void chargeEnergy()
    {

    }

    private void OnDrawGizmosSelected()
    {
        // 트리거 범위를 시각적으로 표시
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
