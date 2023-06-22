using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public Camera cam;
    RaycastHit hit;
    Vector3 screenCenter;
    public float triggerRadius;

    public LeverPuzzle leverPuzzle;
    int layerMask = 1 << 8;
    private void Start()
    {
        layerMask = ~layerMask;
        screenCenter = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);
    }

    private void Update()
    {
        DetectObjectRaycast();
    }

    private void DetectObjectRaycast()
    {
        Ray ray = cam.ScreenPointToRay(screenCenter);
        Debug.DrawRay(transform.position, transform.forward * triggerRadius, Color.red);
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

}
