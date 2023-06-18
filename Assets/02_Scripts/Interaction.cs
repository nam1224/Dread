using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float triggerRadius = 5f; //�÷��̾ �̵��ϸ鼭 ��ȣ�ۿ� ������ ��ü�� Ž���� ����
    public LayerMask targetLayer; //�÷��̾ Ž���� ���̾�� Item

    Vector3 screenCenter;
    private void Start()
    {
        screenCenter = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);
    }

    //Flashlight�� chargeEnergy�� ����ϱ� ����
    public Flashlight flashlight;
    public TextManager textmanager;

    //������ �۵��ϱ� ����
    public LeverPuzzle leverPuzzle;
    public SafePuzzle safePuzzle;
    //
    public GameObject filmLight;
    //Raycast�� ���� ����� ģ����~
    public Camera cam;
    RaycastHit hit;

    int layerMask = 1 << 8; //8���� true
    private void Update()
    {
        DetectObjectRaycase();
        bool detection = DetectObject();
        OnInteractionEnter(detection);
        OnInteractionStay(detection, itemInRange, colliders);
        OnInteractionExit(detection);
    }

    private void DetectObjectRaycase()
    {
        layerMask = ~layerMask;
        Ray ray = cam.ScreenPointToRay(screenCenter);
        //Debug.DrawRay(transform.position, transform.forward * triggerRadius, Color.red);
        //Physics.Raycast(ray ���� ��ġ, ������ �� ����, �浹 ���� hit)
        //Raycast�� ������Ʈ�� �����ǰ� ���콺�� Ŭ���ƴٸ�
        if (Physics.Raycast(transform.position, transform.forward, out hit, layerMask) 
            && Input.GetMouseButtonDown(0))
        {
            //������ ������Ʈ�� ���õ� �Լ�
            leverPuzzle.PullLever(hit);
            Debug.Log(hit.collider.name);
        }
    }


    private bool itemInRange = false;
    private Collider[] colliders;
    private bool DetectObject()
    {
        // ������(��ȣ�ۿ� ������ ��ü)�� Ž���ϴ� �ڵ��Դϴ�.
        colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;
        return isPlayerInRange;
    }
    private void OnInteractionEnter(bool _isPlayerInRange)
    {
        if (!_isPlayerInRange) return;
        itemInRange = true;
    }

    private void OnInteractionStay(bool _itemInRange, bool _isPlayerInRange, Collider[] _colliders)
    {
        if (!_itemInRange || !_isPlayerInRange) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider item in _colliders)
            {
                switch (item.tag)
                {
<<<<<<< HEAD
                    case "Baterry":
                        flashlight.ChargeEnergy();
                        break;
                    case "Key":
                        item.gameObject.SetActive(false);
                        textmanager.Text("GetKey", item.gameObject.ToString());
                        break;
                    case "FilmProjector":
                        filmLight.SetActive(true);
                        break;
                    case "Safe":
                        safePuzzle.OnSafePuzzle();
                        break;
                    default:
                        break;
=======
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

                else if (Input.GetKeyDown(KeyCode.E) && item.tag == "Safe")
                {
                    Debug.Log("Safe");
                    safePuzzle.GetComponent<SafePuzzle>().OnSafePuzzle();
>>>>>>> 9469391d6609bf0b71cf65e6d1c2936d186d95d6
                }
            }
        }
    }

    private void OnInteractionExit(bool _isPlayerInRange)
    {
        if (_isPlayerInRange) return;
        itemInRange = false;
        filmLight.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        // Ʈ���� ������ �ð������� ǥ��
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
