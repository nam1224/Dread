using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float triggerRadius = 5f; //플레이어가 이동하면서 상호작용 가능한 물체르 탐지할 범위
    public LayerMask targetLayer; //플레이어가 탐지할 레이어는 Item

    Vector3 screenCenter;
    private void Start()
    {
        screenCenter = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);
    }

    //Flashlight중 chargeEnergy를 사용하기 위함
    public Flashlight flashlight;
    public TextManager textmanager;

    //퍼즐을 작동하기 위함
    public LeverPuzzle leverPuzzle;
    public SafePuzzleManager SafePuzzleManager;
    //
    public GameObject filmLight;
    //Raycast와 같이 사용할 친구들~
    public Camera cam;
    RaycastHit hit;

    int layerMask = 1 << 8; //8번만 true
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
        //Physics.Raycast(ray 원점 위치, 레이저 쏠 방향, 충돌 감지 hit)
        //Raycast에 오브젝트가 감지되고 마우스가 클릭됐다면
        if (Physics.Raycast(transform.position, transform.forward, out hit, layerMask) 
            && Input.GetMouseButtonDown(0))
        {
            //감지할 오브젝트와 관련된 함수
            leverPuzzle.PullLever(hit);
            Debug.Log(hit.collider.name);
        }
    }


    private bool itemInRange = false;
    private Collider[] colliders;
    private bool DetectObject()
    {
        // 아이템(상호작용 가능한 물체)을 탐지하는 코드입니다.
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
                    case "Baterry":
                        flashlight.ChargeEnergy();
                        Destroy(item);
                        break;
                    case "Key":
                        item.gameObject.SetActive(false);
                        textmanager.Text("GetKey", item.name.ToString());
                        break;
                    case "FilmProjector":
                        filmLight.SetActive(true);
                        break;
                    case "Safe":
                        SafePuzzleManager.CheckSafePuzzle(item);
                        break;
                    default:
                        break;
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
        // 트리거 범위를 시각적으로 표시
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
