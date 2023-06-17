using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost_num1 : Ghost
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
    public GameObject GhostFace;
    public GameObject Ghost_obj;
    public AudioSource GhostAudio;
    public AudioSource GhostAudio1;

    public AudioClip GhostScrem;
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
            }
            // else if (!isPlayerInRange && playerInRange)
            else if (!isPlayerInRange && playerInRange)
            {
                GhostAudio.Stop();
                // �÷��̾ ������ ��� ��쿡 ���� ó�� �ڵ� �ۼ�
                if (PlayerInTime <= TriggerTime)
                {
                    Ghostact0();
                    //�ͽ��� �÷��̾ ���̴� �Լ��� ȣ���մϴ�

                }
                //playerInRange = false;
            }
        }
        if (Spawn == true)
        {
            // �÷��̾ ������ ó�� ������ �� �̺�Ʈ �߻� 
            if (isPlayerInRange && !playerInRange)
            {
                playerInRange = true;
                // �̺�Ʈ �߻� �ڵ� �ۼ�

                GhostSound1();
                // ����Ŵ����� �����Ͽ� ���带 ����ؾ��մϴ�.
            }
            // �÷��̾ ������ ����� �� �÷��� ������Ʈ
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
        //��Ʈ ���� ��¹��
        /*
        ��Ʈ ������ �迭�� ���� (���� ���ҽ�)
        ��Ʈ ���� 1,2 �Լ����� �ش��ϴ� ��Ʈ ���带 ����� (����,�߰ݹ� ���)

        */
    }

    override public void GhostSound2() //kill
    {

    }
}