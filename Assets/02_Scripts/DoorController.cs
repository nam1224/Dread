using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public int OpenYDgree = -90;
    public int OpenXDgree = 0;
    public float openSpeed = 2f; // 문이 열리는 속도
    public bool locked;
    public TextManager textmanager;

    private bool isOpen = false; // 문이 열려있는지 여부를 추적하기 위한 변수
    private bool isDoorAnimating = false; // 문 애니메이션이 진행 중인지 여부를 추적하기 위한 변수
    private Coroutine doorAnimationCoroutine;
    private Quaternion closedRotation; // 닫힌 상태의 회전값
    private Quaternion openedRotation; // 열린 상태의 회전값
    
    private bool isPlayerNearby = false; // 플레이어가 문 주변에 있는지 여부

    private void Start()
    {
        // 닫힌 상태와 열린 상태의 회전값 계산
        closedRotation = transform.rotation;
        openedRotation = Quaternion.Euler(OpenXDgree, OpenYDgree, 0);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && doorAnimationCoroutine == null)
        {
            // 플레이어가 문 주변에서 E 키를 누르고 문 애니메이션이 진행 중이 아닐 때만 문을 열거나 닫기
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