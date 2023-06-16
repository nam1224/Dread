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
    //LeverPuzzle�� �۵��ϱ� ����
    public LeverPuzzle leverPuzzle;
    //
    public GameObject filmLight;
    //Raycast�� ���� ����� ģ����~
    public Camera cam;
    RaycastHit hit;

    int layerMask = 1 << 8; //8���� true
    private void Update()
    {
        DetectObject();
        DetectObjectRaycase();
    }

    private void DetectObjectRaycase()
    {
        layerMask = ~layerMask;
        Ray ray = cam.ScreenPointToRay(screenCenter);
        Debug.DrawRay(transform.position, transform.forward * triggerRadius, Color.red);
        //Physics.Raycast(ray ���� ��ġ, ������ �� ����, �浹 ���� hit)
        //Raycast�� ������Ʈ�� �����ǰ� ���콺�� Ŭ���ƴٸ�
        if (Physics.Raycast(transform.position, transform.forward, out hit, layerMask) && Input.GetMouseButtonDown(0))
        {
            //������ ������Ʈ�� ���õ� �Լ�
            leverPuzzle.PullLever(hit);
            Debug.Log(hit.collider.name);
        }
    }

    private void DetectObject()
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
            //Debug.Log("�÷��̾ �������� �ӹ����� ��");
            //�÷��̾ EŰ�� �����ٸ�
            foreach (Collider item in colliders)
            {
                if (Input.GetKeyDown(KeyCode.E) && item.tag == "Baterry")
                {
                    //�������� ������
                    flashlight.GetComponent<Flashlight>().ChargeEnergy();
                    Debug.Log("������ ����");
                }

                else if (Input.GetKeyDown(KeyCode.E) && item.tag == "Key")
                {
                    item.gameObject.SetActive(false);
                    textmanager.Text("GetKey", item.gameObject.ToString());
                    Debug.Log("���踦 �Ծ����");
                }

                else if (Input.GetKeyDown(KeyCode.E) && item.tag == "FilmProjector")
                {
                    Debug.Log("FilmProjector works");
                    filmLight.SetActive(true);
                }
            }
                
        }

        // �÷��̾ ������ ����� �� �÷��� ������Ʈ
        else if (!isPlayerInRange && itemInRange)
        {
            itemInRange = false;
            //Debug.Log("�÷��̾ ������ ���");
            filmLight.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Ʈ���� ������ �ð������� ǥ��
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
