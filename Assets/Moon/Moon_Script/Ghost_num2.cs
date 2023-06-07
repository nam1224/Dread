using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_num2 : MonoBehaviour
{
    /*
    num2 = 서있는 귀신
     행동방식
     병원 복도에 등장 (1~2층)
     등장시 섬뜩한 소리가 들림.
     일정시간 동안 플레이어가 복도밖으로
     나오지 않으면 사라짐.
     플레이어가 몇초이상 (조절바람) 감지되면
     소리를 내면서 달려옴
     사망 / 층 변경 전까지 따라옴.
    */




    public bool Spawn = false;  // 귀신이 다시 활동을 할수있는지 여부를 확인하는 변수입니다
    public float SpawnTimer = 10f;  // 귀신이 다시 활동을 재개하는 시간 변수 입니다. 테스트용으로 시간을 10f로 정했습니다.
    public float PlayerInTime = 0f; // 플레이어가 귀신의 활동범위 안에 대기한 시간입니다 트리거 타임보다 많다면 사망합니다.
    public float TriggerTime = 4f; // 귀신이 범위안에 들어온 플레이어가 대기해야하는 시간 입니다.

    public float triggerRadius = 5f; // 이벤트를 발생시킬 범위의 반지름 입니다
    public LayerMask targetLayer; // 플레이어를 확인할 레이어 입니다 플레이어의 레이어는 Player_Layer 입니다

    private bool playerInRange = false; // 플레이어가 범위 안에 있는지 여부

    private bool GhostFollow = false;

  
   // private bool PlayerFollow = false; // 트리거 발동시 플레이어를 계속 따라감.
    private void Update()
    {

        if (Spawn == false)  // 귀신이 활동을 끝내어 활동상태가 false 일경우 다시 활동하기위해 쿨타임이 돌아갑니다.
        {
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0f)
            {
                Debug.Log("Ghost_num2 respawn");
                SpawnTimer = 10f;
                Spawn = true;
            }
        }


        if (Spawn == true)  // 귀신이 활동이 가능해질경우 범위안에 들어오는 플레이어를 탐지합니다
        {
            // 플레이어를 탐지하는 코드입니다.
            Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
            bool isPlayerInRange = colliders.Length > 0;


            if (playerInRange == true) // 플레이어가 범위안에 들어와 대기시간만큼 기다릴경우 사망합니다.
            {
                PlayerInTime += Time.deltaTime;

                if (PlayerInTime >= TriggerTime)
                {
                    Debug.Log("Ghost_num2  kill you!!!!!");
                    // 플레이어를 계속따라가는 추격코드.
                    GhostFollow = true;
                }

            }
            // 플레이어가 범위에 처음 들어왔을 때 이벤트 발생 
            if (isPlayerInRange && !playerInRange)
            {
                playerInRange = true;
                // 이벤트 발생 코드 작성

                Debug.Log("Ghost_num1 Wathing you");
                // 사운드매니저에 접근하여 사운드를 재생해야합니다.
            }
            // 플레이어가 범위를 벗어났을 때 플래그 업데이트
            else if (!isPlayerInRange && playerInRange)
            {
                playerInRange = false;
                // 플레이어가 범위를 벗어난 경우에 대한 처리 코드 작성
                if (PlayerInTime < TriggerTime)
                {
                    Debug.Log("Ghost_num2 kill you");

                    GhostFollow = false;

                }
                else if (PlayerInTime > TriggerTime)
                {
                    Debug.Log("Ghost_num2  kill you!!!!!");
                    GhostFollow = true;
                }
            }


            if (GhostFollow == true)
            {

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // 트리거 범위를 시각적으로 표시
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
