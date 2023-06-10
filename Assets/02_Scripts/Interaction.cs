using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float triggerRadius = 5f; //�÷��̾ �̵��ϸ鼭 ��ȣ�ۿ� ������ ��ü�� Ž���� ����
    public LayerMask targetLayer; //�÷��̾ Ž���� ���̾�� Item

    private bool itemInRange = false;

    private void Start()
    {
        
    }

    //Flashlight�� chargeEnergy�� ����ϱ� ����
    public Flashlight flashlight;
    private void Update()
    {
        // �÷��̾ Ž���ϴ� �ڵ��Դϴ�.
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;


        // �÷��̾ ������ ó�� ������ �� �̺�Ʈ �߻� 
        if (isPlayerInRange && !itemInRange)
        {
            itemInRange = true;
            //Debug.Log("�÷��̾ ������ ����");
        }

        //�÷��̾ ������ ��� �ӹ��� ��
        else if (isPlayerInRange && itemInRange)
        {
            Debug.Log("�÷��̾ �������� �ӹ����� ��");
            //�÷��̾ EŰ�� �����ٸ�
            for (int i = 0; i < colliders.Length; i++)
                if (Input.GetKeyDown(KeyCode.E) && colliders[i].tag == "Bettery")
                {
                    //�������� ������
                    flashlight.GetComponent<Flashlight>().chargeEnergy();
                    Debug.Log("������ ����");
                }
        }

        // �÷��̾ ������ ����� �� �÷��� ������Ʈ
        else if (!isPlayerInRange && itemInRange)
        {
            itemInRange = false;
            //Debug.Log("�÷��̾ ������ ���");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Ʈ���� ������ �ð������� ǥ��
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
