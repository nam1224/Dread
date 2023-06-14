using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_playerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName = "Mouse X";
    [SerializeField] private string mouseYInputName = "Mouse Y";
    [SerializeField] public float mouseSensitivity;

    [SerializeField] private Transform playerBody;
    private float xAxisClamp;
    private bool m_cursorIsLocked = true;

    private void Awake()
    {
        xAxisClamp = 0.0f;
    }

    Vector3 screenCenter;
    private void Start()
    {
        LockCursor();
        screenCenter = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);
    }
    private void LockCursor()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
    public Camera cam;
    RaycastHit hit;
    private void Update()
    {
        CameraRotation();
        Ray ray = cam.ScreenPointToRay(screenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        //Physics.Raycast(ray ���� ��ġ, ������ �� ����, �浹 ���� hit)
        //Raycast�� ������Ʈ�� �����ǰ� ���콺�� Ŭ���ƴٸ�
        if (Physics.Raycast(transform.position, transform.forward, out hit) && Input.GetMouseButtonDown(0))
        {
            //������ ������Ʈ�� ���õ� �Լ�
        }
    }

    //ī�޶� ȸ��
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
