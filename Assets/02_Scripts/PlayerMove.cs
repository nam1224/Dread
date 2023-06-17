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
    public AudioSource WalkSound;
    public bool Moveing = false;
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
 
        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        Vector3 movement = forwardMovement + rightMovement;
        movement = Vector3.ClampMagnitude(movement, movementSpeed); // ���� ũ�⸦ movementSpeed�� ����

        // SimpleMove �޼ҵ�� deltaTime�� �ڵ����� �����մϴ�.
        charController.SimpleMove(movement);
        if(vertInput > 0 || horizInput > 0 || vertInput < 0 || horizInput <0)
        {
            Moveing = true;
        }
        else
        {
            Moveing = false;
        }
        Get_KeyCode();

    }

    public void Get_KeyCode()
    {
        
       /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("W");
            Moveing = true;
        }
        else
        {
            print("Moveing = false");

            Moveing = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("S");
            Moveing = true;
        }
        else
        {
            print("Moveing = false");

            Moveing = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("D");
            Moveing = true;
        }
        else
        {
            print("Moveing = false");

            Moveing = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("W");
            Moveing = true;
        }
        else
        {
            print("Moveing = false");

            Moveing = false;
        }
       */

        if (Moveing == true)
        {
            Debug.Log("walkSoundPlay"); // ���߿� �����
            WalkSound.Play();
        }
        else
        {
            Debug.Log("walkSoundStop"); // ���߿� �����
            WalkSound.Stop();
        }
    }


}
