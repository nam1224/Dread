using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float triggerRadius = 5f; //플레이어가 이동하면서 상호작용 가능한 물체르 탐지할 범위
    public LayerMask targetLayer; //플레이어가 탐지할 레이어는 Item

    private bool itemInRange = false;

    Vector3 screenCenter;
    private void Start()
    {
        screenCenter = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);
    }

    //Flashlight중 chargeEnergy를 사용하기 위함
    public Flashlight flashlight;
    public TextManager textmanager;
    //LeverPuzzle를 작동하기 위함
    public LeverPuzzle leverPuzzle;
    //
    public GameObject filmLight;
    //Raycast와 같이 사용할 친구들~
    public Camera cam;
    RaycastHit hit;

    int layerMask = 1 << 8; //8번만 true
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
        //Physics.Raycast(ray 원점 위치, 레이저 쏠 방향, 충돌 감지 hit)
        //Raycast에 오브젝트가 감지되고 마우스가 클릭됐다면
        if (Physics.Raycast(transform.position, transform.forward, out hit, layerMask) && Input.GetMouseButtonDown(0))
        {
            //감지할 오브젝트와 관련된 함수
            leverPuzzle.PullLever(hit);
            Debug.Log(hit.collider.name);
        }
    }

    private void DetectObject()
    {
        // 플레이어를 탐지하는 코드입니다.
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius, targetLayer);
        bool isPlayerInRange = colliders.Length > 0;

        // 플레이어가 범위에 처음 들어왔을 때 이벤트 발생 
        if (isPlayerInRange && !itemInRange)
        {
            itemInRange = true;
            //Debug.Log("플레이어가 범위에 들어옴");
        }

        //플레이어가 범위에 계속 머무를 때
        else if (isPlayerInRange && itemInRange)
        {
            //Debug.Log("플레이어가 범위에서 머무르는 중");
            //플레이어가 E키를 누른다면
            foreach (Collider item in colliders)
            {
                if (Input.GetKeyDown(KeyCode.E) && item.tag == "Baterry")
                {
                    //에너지를 충전함
                    flashlight.GetComponent<Flashlight>().ChargeEnergy();
                    Debug.Log("에너지 충전");
                }

                else if (Input.GetKeyDown(KeyCode.E) && item.tag == "Key")
                {
                    item.gameObject.SetActive(false);
                    textmanager.Text("GetKey", item.gameObject.ToString());
                    Debug.Log("열쇠를 먹어버림");
                }

                else if (Input.GetKeyDown(KeyCode.E) && item.tag == "FilmProjector")
                {
                    Debug.Log("FilmProjector works");
                    filmLight.SetActive(true);
                }
            }
                
        }

        // 플레이어가 범위를 벗어났을 때 플래그 업데이트
        else if (!isPlayerInRange && itemInRange)
        {
            itemInRange = false;
            //Debug.Log("플레이어가 범위를 벗어남");
            filmLight.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // 트리거 범위를 시각적으로 표시
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
