using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInput, mouseYInput;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

    // Start is called before the first frame update

    private void Start() {
        LockCursor();
        xAxisClamp = 0;
    }

    private void Update() {
        CameraRotation();
    }

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation() {
        float mouseX = Input.GetAxis(mouseXInput)*mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInput)*mouseSensitivity*Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f) {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        } else if (xAxisClamp < -90.0f) {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
