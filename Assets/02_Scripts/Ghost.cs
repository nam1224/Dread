using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public bool Spawn = false;  // �ͽ��� �ٽ� Ȱ���� �Ҽ��ִ��� ���θ� Ȯ���ϴ� �����Դϴ�
    public float SpawnTimer = 10f;  // �ͽ��� �ٽ� Ȱ���� �簳�ϴ� �ð� ���� �Դϴ�. �׽�Ʈ������ �ð��� 10f�� ���߽��ϴ�.
    public float PlayerInTime = 0f; // �÷��̾ �ͽ��� Ȱ������ �ȿ� ����� �ð��Դϴ� Ʈ���� Ÿ�Ӻ��� ���ٸ� ����մϴ�.
    public float TriggerTime = 4f; // �ͽ��� �����ȿ� ���� �÷��̾ ����ؾ��ϴ� �ð� �Դϴ�.

    public float triggerRadius = 5f; // �̺�Ʈ�� �߻���ų ������ ������ �Դϴ�
    public LayerMask targetLayer; // �÷��̾ Ȯ���� ���̾� �Դϴ� �÷��̾��� ���̾�� Player_Layer �Դϴ�

    public  bool playerInRange = false; // �÷��̾ ���� �ȿ� �ִ��� ����


    private void Update()
    {
        if (Spawn == false)
        {
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0f)
            {
                Debug.Log("Ghost_num1 respawn");
                SpawnTimer = 10f;
                Spawn = true;
            }
        }
        else if (Spawn == true)
        {
            GhostAct();
        }
    }



    public void GhostAct()
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

            }
        // �÷��̾ ������ ó�� ������ �� �̺�Ʈ �߻� 
        if (isPlayerInRange && !playerInRange)
        {
            playerInRange = true;
            // �̺�Ʈ �߻� �ڵ� �ۼ�

            GhostSound();
            // ����Ŵ����� �����Ͽ� ���带 ����ؾ��մϴ�.
        }
        // �÷��̾ ������ ����� �� �÷��� ������Ʈ
        else if (!isPlayerInRange && playerInRange)
        {
            playerInRange = false;
            // �÷��̾ ������ ��� ��쿡 ���� ó�� �ڵ� �ۼ�
            if (PlayerInTime < TriggerTime)
            {
                Ghostact0();
                //�ͽ��� �÷��̾ ���̴� �Լ��� ȣ���մϴ�

            }

        }
    }
    virtual public void Ghostact0()
    {
        Debug.Log("Ghost_act0");
    }
    virtual public void Ghostact1()
    {
        Debug.Log("Ghost_act1");
    }
    virtual public void GhostSound()
    {
        Debug.Log("GhostSound_Play");
    }
    private void OnDrawGizmosSelected()
    {
        // Ʈ���� ������ �ð������� ǥ��
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}