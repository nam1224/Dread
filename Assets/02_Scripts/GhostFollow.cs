using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : Ghost
{
    private NavMeshAgent Ghost;
    public AudioSource GhostAudio;

    public Transform PlayerTarget;

    public float LifeTimer = 40f;
    public GameObject Ghost_Object;
    // Start is called before the first frame update
    void Start()
    {
        Ghost = GetComponent<NavMeshAgent>();
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;

        FollowPlayer();
        LifeTimer -= Time.deltaTime;

        if (LifeTimer <= 0f)
        {
         Debug.Log("Ghost_num3 Spawn False");
         Destroy(Ghost_Object,0.5f);
        }


        if (playerInRange == true) // 플레이어가 범위안에 들어와 대기시간만큼 기다릴경우 행동하는코드입니다
        {
            PlayerInTime += Time.deltaTime;

            if (PlayerInTime >= TriggerTime)
            {
                Ghostact1();

                PlayerInTime = 0;

                // 플레이어가 들어올경우 전력을 깎는 행동을 취함.
            }

        }
        // 플레이어가 범위에 처음 들어왔을 때 이벤트 발생 
        if (isPlayerInRange && !playerInRange)
        {
            playerInRange = true;
            // 이벤트 발생 코드 작성

            GhostSound1();
            // 사운드매니저에 접근하여 사운드를 재생해야합니다.
        }
        // 플레이어가 범위를 벗어났을 때 플래그 업데이트
        else if (!isPlayerInRange && playerInRange)
        {
            playerInRange = false;
            GhostAudio.Stop();
        }

    }


    override public void Ghostact0()
    {
        GhostSound1();
    }
    override public void Ghostact1()
    {
        Damaged();
    }
    // Update is called once per frame
    private void FollowPlayer()
    {
        Ghost.SetDestination(PlayerTarget.position);
    }

    override public void GhostSound1()
    {
        GhostAudio.Play();
        Debug.Log("GhostSound_Play1");
    }
}
