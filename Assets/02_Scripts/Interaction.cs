using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float triggerRadius = 5f; //�÷��̾ �̵��ϸ鼭 ��ȣ�ۿ� ������ ��ü�� Ž���� ����
    public LayerMask targetLayer; //�÷��̾ Ž���� ���̾�� Item

    private bool itemInRange = false;

    Vector3 screenCenter;
    private void Start()
    {
        screenCenter = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);
    }

    //Flashlight�� chargeEnergy�� ����ϱ� ����
    public Flashlight flashlight;
    public TextManager textmanager;
    public LeverPuzzle leverPuzzle;

    //Raycast�� ���� ����� ģ����~
    public Camera cam;
    RaycastHit hit;


    private void Update()
    {
        // �÷��̾ Ž���ϴ� �ڵ��Դϴ�.
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;

        Ray ray = cam.ScreenPointToRay(screenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        //Physics.Raycast(ray ���� ��ġ, ������ �� ����, �浹 ���� hit)
        //Raycast�� ������Ʈ�� �����ǰ� ���콺�� Ŭ���ƴٸ�
        if (Physics.Raycast(transform.position, transform.forward, out hit) && Input.GetMouseButtonDown(0))
        {
            //������ ������Ʈ�� ���õ� �Լ�
            leverPuzzle.PullLever(hit);
            Debug.Log(hit.collider.name);
        }

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
                if (Input.GetKeyDown(KeyCode.E) && colliders[i].tag == "Baterry")
                {
                    //�������� ������
                    flashlight.GetComponent<Flashlight>().ChargeEnergy();
                    Debug.Log("������ ����");
                }
                else if (Input.GetKeyDown(KeyCode.E) && colliders[i].tag == "Key")
                {
                    colliders[i].gameObject.SetActive(false);
                    textmanager.Text("GetKey", colliders[i].gameObject.ToString());
                    Debug.Log("���踦 �Ծ����");
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
