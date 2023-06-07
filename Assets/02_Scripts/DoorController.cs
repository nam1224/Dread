using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public int OpenDgree = -90;
    public float openSpeed = 2f; // ���� ������ �ӵ�

    private bool isOpen = false; // ���� �����ִ��� ���θ� �����ϱ� ���� ����
    private bool isDoorAnimating = false; // �� �ִϸ��̼��� ���� ������ ���θ� �����ϱ� ���� ����
    private Quaternion closedRotation; // ���� ������ ȸ����
    private Quaternion openedRotation; // ���� ������ ȸ����
    
    private bool isPlayerNearby = false; // �÷��̾ �� �ֺ��� �ִ��� ����

    private void Start()
    {
        // ���� ���¿� ���� ������ ȸ���� ���
        closedRotation = transform.rotation;
        openedRotation = Quaternion.Euler(0, OpenDgree, 0);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !isDoorAnimating)
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
        StopAllCoroutines(); // ������ �� ���� �ڷ�ƾ�� ����

        StartCoroutine(OpenAnimation());
    }

    private void CloseDoor()
    {
        StopAllCoroutines(); // ������ �� ���� �ڷ�ƾ�� ����

        StartCoroutine(CloseAnimation());
    }

    private IEnumerator OpenAnimation()
    {
        isDoorAnimating = true;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.rotation = Quaternion.Lerp(closedRotation, openedRotation, t);
            yield return null;
        }
        isOpen = true;
        isDoorAnimating = false;
    }

    private IEnumerator CloseAnimation()
    {
        isDoorAnimating = true;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.rotation = Quaternion.Lerp(openedRotation, closedRotation, t);
            yield return null;
        }
        isOpen = false;
        isDoorAnimating = false;
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