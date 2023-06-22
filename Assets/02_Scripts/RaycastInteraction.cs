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

}
