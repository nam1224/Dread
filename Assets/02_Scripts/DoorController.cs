using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public int OpenYDgree = -90;
    public int OpenXDgree = 0;
    public float openSpeed = 2f; // ���� ������ �ӵ�
    public bool locked;
    public TextManager textmanager;

    private bool isOpen = false; // ���� �����ִ��� ���θ� �����ϱ� ���� ����
    private bool isDoorAnimating = false; // �� �ִϸ��̼��� ���� ������ ���θ� �����ϱ� ���� ����
    private Coroutine doorAnimationCoroutine;
    private Quaternion closedRotation; // ���� ������ ȸ����
    private Quaternion openedRotation; // ���� ������ ȸ����
    
    private bool isPlayerNearby = false; // �÷��̾ �� �ֺ��� �ִ��� ����

    private void Start()
    {
        // ���� ���¿� ���� ������ ȸ���� ���
        closedRotation = transform.rotation;
        openedRotation = Quaternion.Euler(OpenXDgree, OpenYDgree, 0);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && doorAnimationCoroutine == null)
        {
            // �÷��̾ �� �ֺ����� E Ű�� ������ �� �ִϸ��̼��� ���� ���� �ƴ� ���� ���� ���ų� �ݱ�
            if (isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        doorAnimationCoroutine = StartCoroutine(OpenAnimation());
    }

    private void CloseDoor()
    {
        doorAnimationCoroutine = StartCoroutine(CloseAnimation());
    }

    private IEnumerator OpenAnimation()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.rotation = Quaternion.Lerp(closedRotation, openedRotation, t);
            yield return null;
        }
        isOpen = true;
        doorAnimationCoroutine = null;
    }

    private IEnumerator CloseAnimation()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.rotation = Quaternion.Lerp(openedRotation, closedRotation, t);
            yield return null;
        }
        isOpen = false;
        doorAnimationCoroutine = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}