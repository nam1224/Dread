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


    override public void Ghostact0()
    {

        Debug.Log("GhostKillYou");
        GhostFace.gameObject.SetActive(true);
    }
    override public void Ghostact1()
    {
        Debug.Log("GhostUnSpawn");
        Spawn = false;
        PlayerInTime = 0f; 
        TriggerTime = 4f;
    }
    override public void GhostSound1()
    {
        //��Ʈ ���� ��¹��
        /*
        ��Ʈ ������ �迭�� ���� (���� ���ҽ�)
        ��Ʈ ���� 1,2 �Լ����� �ش��ϴ� ��Ʈ ���带 ����� (����,�߰ݹ� ���)

        */
    }

    override public void GhostSound2()
    {

    }
}