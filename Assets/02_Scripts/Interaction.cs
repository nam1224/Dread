using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float triggerRadius = 5f; //�÷��̾ �̵��ϸ鼭 ��ȣ�ۿ� ������ ��ü�� Ž���� ����
    public LayerMask targetLayer; //�÷��̾ Ž���� ���̾�� Item

    //Flashlight�� chargeEnergy�� ����ϱ� ����
    public Flashlight flashlight;
    public TextManager textmanager;

    //������ �۵��ϱ� ����
    public LeverPuzzle leverPuzzle;
    public SafePuzzleManager SafePuzzleManager;
    public GameObject filmLight;
    //Raycast�� ���� ����� ģ����~

    private void Update()
    {
        bool detection = DetectObject();
        OnInteractionEnter(detection);
        OnInteractionStay(detection, itemInRange, colliders);
        OnInteractionExit(detection);
    }


    private bool itemInRange = false;
    private Collider[] colliders;
    private bool DetectObject()
    {
        // ������(��ȣ�ۿ� ������ ��ü)�� Ž���ϴ� �ڵ��Դϴ�.
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
        // Ʈ���� ������ �ð������� ǥ��
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
