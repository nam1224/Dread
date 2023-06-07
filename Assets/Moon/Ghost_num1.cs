using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_num1 : MonoBehaviour
{
    public bool Spawn = false;  // �ͽ��� �ٽ� Ȱ���� �Ҽ��ִ��� ���θ� Ȯ���ϴ� �����Դϴ�
    public float SpawnTimer = 10f;  // �ͽ��� �ٽ� Ȱ���� �簳�ϴ� �ð� ���� �Դϴ�. �׽�Ʈ������ �ð��� 10f�� ���߽��ϴ�.
    public float PlayerInTime = 0f; // �÷��̾ �ͽ��� Ȱ������ �ȿ� ����� �ð��Դϴ� Ʈ���� Ÿ�Ӻ��� ���ٸ� ����մϴ�.
    public float TriggerTime= 4f; // �ͽ��� �����ȿ� ���� �÷��̾ ����ؾ��ϴ� �ð� �Դϴ�.

    public float triggerRadius = 5f; // �̺�Ʈ�� �߻���ų ������ ������ �Դϴ�
    public LayerMask targetLayer; // �÷��̾ Ȯ���� ���̾� �Դϴ� �÷��̾��� ���̾�� Player_Layer �Դϴ�

    private bool playerInRange = false; // �÷��̾ ���� �ȿ� �ִ��� ����
    public GameObject GhostFace;
    private void Update()
    {

        if (Spawn == false)  // �ͽ��� Ȱ���� ������ Ȱ�����°� false �ϰ�� �ٽ� Ȱ���ϱ����� ��Ÿ���� ���ư��ϴ�.
        {
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0f)
            {
                Debug.Log("Ghost_num1 respawn");
                SpawnTimer = 10f;
                Spawn = true;
            }
        }
        

        if(Spawn ==true)  // �ͽ��� Ȱ���� ����������� �����ȿ� ������ �÷��̾ Ž���մϴ�
        {
             // �÷��̾ Ž���ϴ� �ڵ��Դϴ�.
            Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
            bool isPlayerInRange = colliders.Length > 0;


            if(playerInRange == true) // �÷��̾ �����ȿ� ���� ���ð���ŭ ��ٸ���� ����ִ� �ڵ��Դϴ�
            {
                PlayerInTime += Time.deltaTime;

                if (PlayerInTime >= TriggerTime)
                {
                    Debug.Log("Ghost_num1 not kill you");
                    SpawnTimer = 10f;
                    PlayerInTime = 0f;
                    Spawn = false;
                }

            }
            // �÷��̾ ������ ó�� ������ �� �̺�Ʈ �߻� 
            if (isPlayerInRange && !playerInRange)
            {
                playerInRange = true;
                // �̺�Ʈ �߻� �ڵ� �ۼ�

                Debug.Log("Ghost_num1 Wathing you");
                // ����Ŵ����� �����Ͽ� ���带 ����ؾ��մϴ�.
            }
            // �÷��̾ ������ ����� �� �÷��� ������Ʈ
            else if (!isPlayerInRange && playerInRange)
            {
                playerInRange = false;
                // �÷��̾ ������ ��� ��쿡 ���� ó�� �ڵ� �ۼ�
                if (PlayerInTime < TriggerTime)
                {
                    Debug.Log("Ghost kill you");
                    GhostFace.SetActive(true);
                    //�ͽ��� �÷��̾ ���̴� �Լ��� ȣ���մϴ�

                }
               
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Ʈ���� ������ �ð������� ǥ��
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
