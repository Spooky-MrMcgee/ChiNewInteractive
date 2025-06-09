using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraRotate : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCam;
    [SerializeField] GameObject rotate, arrow;
    [SerializeField] float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ICinemachineCamera mainCam = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera;
        if (vCam.gameObject != mainCam.VirtualCameraGameObject)
        {
            arrow.SetActive(true);
            return;
        }

        arrow.SetActive(false);

        if (Input.GetKey(KeyCode.A))
        {
            rotate.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotate.transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
    }
}
