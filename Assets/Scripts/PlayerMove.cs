using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string horizontalInput;
    [SerializeField] private string verticalInput;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement() {
        float hInput = Input.GetAxis(horizontalInput) * movementSpeed;
        float vInput = Input.GetAxis(verticalInput) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vInput;
        Vector3 rightMovement = transform.right * hInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }
}
