using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_playerLook : MonoBehaviour
{
    //[SerializeField] private string mouseXInputName = "Mouse X";
    //[SerializeField] private string mouseYInputName = "Mouse Y";
    //[SerializeField] public float mouseSensitivity = 150f;

    //[SerializeField] private Transform playerBody;
    //private float xAxisClamp;
    //private bool m_cursorIsLocked = true;

    ////public GameObject op;

    //private void Awake()
    //{
    //    //LockCursor();
    //    xAxisClamp = 0.0f;
    //    //mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
    //}

    //private void LockCursor()
    //{
    //    if (Input.GetKeyUp(KeyCode.Escape))
    //    {
    //        m_cursorIsLocked = false;
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        m_cursorIsLocked = true;
    //    }

    //    if (m_cursorIsLocked)
    //    {
    //        //CursorLockMode.Locked는 화면 정중앙에 커서를 배치하고 잠금
    //        Cursor.lockState = CursorLockMode.Locked;
    //        Cursor.visible = false;
    //    }
    //    else if (!m_cursorIsLocked)
    //    {
    //        Cursor.lockState = CursorLockMode.None;
    //        Cursor.visible = true;
    //    }

    //}

    //private void Update()
    //{
    //    CameraRotation();
    //}

    //private void CameraRotation()
    //{
    //    float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
    //    float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

    //    xAxisClamp += mouseY;

    //    if (xAxisClamp > 90.0f)
    //    {
    //        xAxisClamp = 90.0f;
    //        mouseY = 0.0f;
    //        ClampXAxisRotationToValue(270.0f);
    //    }
    //    else if (xAxisClamp < -90.0f)
    //    {
    //        xAxisClamp = -90.0f;
    //        mouseY = 0.0f;
    //        ClampXAxisRotationToValue(90.0f);
    //    }

    //    transform.Rotate(Vector3.left * mouseY);
    //    playerBody.Rotate(Vector3.up * mouseX);
    //}

    //private void ClampXAxisRotationToValue(float value)
    //{
    //    Vector3 eulerRotation = transform.eulerAngles;
    //    eulerRotation.x = value;
    //    transform.eulerAngles = eulerRotation;
    //}

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {   
            Debug.Log(hit.transform.name);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.red);
        }
        else
        {
            Debug.Log("nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
        }
    }
}
