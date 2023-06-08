using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeInteraction : MonoBehaviour
{
    public float triggerRadius = 5f; // �̺�Ʈ�� �߻���ų ������ ������ �Դϴ�
    public LayerMask targetLayer; // �÷��̾ Ȯ���� ���̾� �Դϴ� �÷��̾��� ���̾�� Player_Layer �Դϴ�

    bool isInRange = false;
    private bool playerInRange = false;

    private void Update()
    {
        // �÷��̾ Ž���ϴ� �ڵ��Դϴ�.
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;

        // �÷��̾ ������ ó�� ������ �� �̺�Ʈ �߻� 
        if (isPlayerInRange && !playerInRange)
        {
            playerInRange = true;
            // �̺�Ʈ �߻� �ڵ� �ۼ�
            Debug.Log("�÷��̾ ������ ó�� ������ �� �̺�Ʈ �߻� ");
            // ����Ŵ����� �����Ͽ� ���带 ����ؾ��մϴ�.
        }

        // �÷��̾ ������ ����� �� �÷��� ������Ʈ
        else if (!isPlayerInRange && playerInRange)
        {
            playerInRange = false;
            Debug.Log("�÷��̾ ������ ����� �� �÷��� ������Ʈ");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Ʈ���� ������ �ð������� ǥ��
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
