using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSens;
    [SerializeField] private Transform playerMesh;
    private float xRotation, yRotation, cameraX = 0f, cameraY = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update() 
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        xRotation =  Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSens;
        yRotation =  Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSens;

        cameraY += xRotation;
        cameraX -= yRotation;

        cameraX = Mathf.Clamp(cameraX, -90f, 90f);

        transform.rotation = Quaternion.Euler(cameraX, cameraY, 0);
        playerMesh.rotation = Quaternion.Euler(0, cameraY, 0); 
    }
}
