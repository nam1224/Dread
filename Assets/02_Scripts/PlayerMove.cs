using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float movementSpeed = 2f;
    public bool Moveing;
    private CharacterController charController;
    public AudioSource PlayerAudio;
    public AudioClip WalkSound;
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerWalkSound();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        Vector3 movement = forwardMovement + rightMovement;
        movement = Vector3.ClampMagnitude(movement, movementSpeed); // ���� ũ�⸦ movementSpeed�� ����

        // SimpleMove �޼ҵ�� deltaTime�� �ڵ����� �����մϴ�.
        charController.SimpleMove(movement);

        if (vertInput > 0 || horizInput > 0 || vertInput < 0 || horizInput < 0)
        {
            Moveing = true;
        }
        else
        {
            Moveing = false;
        }
        
    }
    public void PlayerWalkSound()
    {
        if (Moveing == true)
        {
            PlayerAudio.PlayOneShot(WalkSound, 1.0f);
        }
    }
}
