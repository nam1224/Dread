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


        if (playerInRange == true) // �÷��̾ �����ȿ� ���� ���ð���ŭ ��ٸ���� �ൿ�ϴ��ڵ��Դϴ�
        {
            PlayerInTime += Time.deltaTime;

            if (PlayerInTime >= TriggerTime)
            {
                Ghostact1();

                PlayerInTime = 0;

                // �÷��̾ ���ð�� ������ ��� �ൿ�� ����.
            }

        }
        // �÷��̾ ������ ó�� ������ �� �̺�Ʈ �߻� 
        if (isPlayerInRange && !playerInRange)
        {
            playerInRange = true;
            // �̺�Ʈ �߻� �ڵ� �ۼ�

            GhostSound1();
            // ����Ŵ����� �����Ͽ� ���带 ����ؾ��մϴ�.
        }
        // �÷��̾ ������ ����� �� �÷��� ������Ʈ
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
