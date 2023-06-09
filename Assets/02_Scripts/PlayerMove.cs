using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float movementSpeed = 2f;

    private CharacterController charController;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMovement = (transform.forward * vertInput);
        Vector3 rightMovement = (transform.right * horizInput);

        Vector3 movement =  forwardMovement + rightMovement;

        //Vector3.ClampMagnitude(�̵�����, �̵��ӵ� �ִ�)
        movement = Vector3.ClampMagnitude(movement, movementSpeed);

        charController.SimpleMove(movement);
    }
}
