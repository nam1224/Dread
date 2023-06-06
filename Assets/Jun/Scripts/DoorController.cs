using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public float openSpeed = 2f; // 문이 열리는 속도

    private bool isOpen = false; // 문이 열려있는지 여부를 추적하기 위한 변수
    private Quaternion closedRotation; // 닫힌 상태의 회전값
    private Quaternion openedRotation; // 열린 상태의 회전값

    private bool isPlayerNearby = false; // 플레이어가 문 주변에 있는지 여부

    private void Start()
    {
        // 닫힌 상태와 열린 상태의 회전값 계산
        closedRotation = transform.rotation;
        openedRotation = Quaternion.Euler(0, 90, 0);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // 플레이어가 문 주변에서 E 키를 누를 때 문을 열거나 닫기
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
        StopAllCoroutines(); // 기존의 문 동작 코루틴을 중지

        StartCoroutine(OpenAnimation());
    }

    private void CloseDoor()
    {
        StopAllCoroutines(); // 기존의 문 동작 코루틴을 중지

        StartCoroutine(CloseAnimation());
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