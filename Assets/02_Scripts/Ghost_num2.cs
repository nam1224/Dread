using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost_num2 : Ghost
{
    /* Ghost ��� �ڵ�
    public bool Spawn = false;  // �ͽ��� �ٽ� Ȱ���� �Ҽ��ִ��� ���θ� Ȯ���ϴ� �����Դϴ�
    public float SpawnTimer = 10f;  // �ͽ��� �ٽ� Ȱ���� �簳�ϴ� �ð� ���� �Դϴ�. �׽�Ʈ������ �ð��� 10f�� ���߽��ϴ�.
    public float PlayerInTime = 0f; // �÷��̾ �ͽ��� Ȱ������ �ȿ� ����� �ð��Դϴ� Ʈ���� Ÿ�Ӻ��� ���ٸ� ����մϴ�.
    public float TriggerTime= 4f; // �ͽ��� �����ȿ� ���� �÷��̾ ����ؾ��ϴ� �ð� �Դϴ�.

    public float triggerRadius = 5f; // �̺�Ʈ�� �߻���ų ������ ������ �Դϴ�
    public LayerMask targetLayer; // �÷��̾ Ȯ���� ���̾� �Դϴ� �÷��̾��� ���̾�� Player_Layer �Դϴ�
    
    private bool playerInRange = false; // �÷��̾ ���� �ȿ� �ִ��� ����
    */

    //2�� �ͽ� : ����� ���� �ͽ� �����ð����� �����Ǿ��ְ� �����ȿ� ������ ĳ������ ������ ���ҽ�Ŵ.

    public float LifeTimer = 30f; // �ش�ͽ��� ���� ���� �������ִ� �ð� ������ �ٽ� ���� Ÿ�̸Ӹ� ��ٸ���.
    public GameObject Ghost_obj;
    public AudioSource GhostAudio;
    void start()
    {
        GhostAudio = GetComponent<AudioSource>();

    }
    override public void Update()
    {
        if (Spawn == false)
        {
            Ghost_obj.gameObject.SetActive(false);
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0f)
            {
                Debug.Log("Ghost_num2 respawn");
                SpawnTimer = 10f;
                Spawn = true;
            }
        }
        else if (Spawn == true)
        {
            Ghost_obj.gameObject.SetActive(true);
            LifeTimer -= Time.deltaTime;
            
            if(LifeTimer <= 0f)
            {
                Debug.Log("Ghost_num2 respawn");
                LifeTimer = 30f;
                Spawn = false;
            }
            GhostAct();
        }
    }

    override public void GhostAct()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;

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

       
    }
    override public void Ghostact1()
    {
        // �ش� �ͽ��� �÷��̾��� ������ ��� �Լ��� ȣ����.
        Debug.Log("Ghost Attack!");

    }
    override public void GhostSound1()
    {
        GhostAudio.Play();
        //��Ʈ ���� ��¹��
        /*
        ��Ʈ ������ �迭�� ���� (���� ���ҽ�)
        ��Ʈ ���� 1,2 �Լ����� �ش��ϴ� ��Ʈ ���带 ����� (����,�߰ݹ� ���)
        �ش� �ͽ� ���Լ��� �� �Ҹ��� �����.
        */
    }

    override public void GhostSound2()
    {

    }
}