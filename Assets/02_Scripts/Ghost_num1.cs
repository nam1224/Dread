using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost_num1 : Ghost
{
    /* Ghost 상속 코드
    public bool Spawn = false;  // 귀신이 다시 활동을 할수있는지 여부를 확인하는 변수입니다
    public float SpawnTimer = 10f;  // 귀신이 다시 활동을 재개하는 시간 변수 입니다. 테스트용으로 시간을 10f로 정했습니다.
    public float PlayerInTime = 0f; // 플레이어가 귀신의 활동범위 안에 대기한 시간입니다 트리거 타임보다 적다면 사망합니다.
    public float TriggerTime= 4f; // 귀신이 범위안에 들어온 플레이어가 대기해야하는 시간 입니다.

    public float triggerRadius = 5f; // 이벤트를 발생시킬 범위의 반지름 입니다
    public LayerMask targetLayer; // 플레이어를 확인할 레이어 입니다 플레이어의 레이어는 Player_Layer 입니다
    
    private bool playerInRange = false; // 플레이어가 범위 안에 있는지 여부
    */
    public GameObject GhostFace;
    public GameObject Ghost_obj;
    public AudioSource GhostAudio;
    public AudioSource GhostAudio1;

    public AudioClip GhostScrem;
    override public void GhostAct()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;

        if (playerInRange == true) // 플레이어가 범위안에 들어와 대기시간만큼 기다릴경우 행동하는코드입니다
        {
            PlayerInTime += Time.deltaTime;

            if (PlayerInTime >= TriggerTime)
            {
                Ghostact1();
            }
            // else if (!isPlayerInRange && playerInRange)
            else if (!isPlayerInRange && playerInRange)
            {
                GhostAudio.Stop();
                // 플레이어가 범위를 벗어난 경우에 대한 처리 코드 작성
                if (PlayerInTime <= TriggerTime)
                {
                    Ghostact0();
                    //귀신이 플레이어를 죽이는 함수를 호출합니다

                }
                //playerInRange = false;
            }
        }
        if (Spawn == true)
        {
            // 플레이어가 범위에 처음 들어왔을 때 이벤트 발생 
            if (isPlayerInRange && !playerInRange)
            {
                playerInRange = true;
                // 이벤트 발생 코드 작성

                GhostSound1();
                // 사운드매니저에 접근하여 사운드를 재생해야합니다.
            }
            // 플레이어가 범위를 벗어났을 때 플래그 업데이트
        }
        else if(Spawn != true)
        {
            GhostAudio.Stop();
            playerInRange = false;
        }

        
    }


    override public void Ghostact0()
    {

        Debug.Log("GhostKillYou");
        GhostAudio1.PlayOneShot(GhostScrem,1.0f);
        GhostFace.gameObject.SetActive(true);
    }
    override public void Ghostact1()
    {
        playerInRange = false;
        Debug.Log("GhostUnSpawn");
        Spawn = false;
        PlayerInTime = 0f; 
        TriggerTime = 6f;
    }
    override public void GhostSound1()
    {

        GhostAudio.Play();
        //고스트 사운드 출력방식
        /*
        고스트 개별로 배열을 받음 (사운드 리소스)
        고스트 사운드 1,2 함수에서 해당하는 고스트 사운드를 출력함 (등장,추격및 비명)

        */
    }

    override public void GhostSound2() //kill
    {

    }
}