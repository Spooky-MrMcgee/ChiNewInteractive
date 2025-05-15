using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CineCsmScript : MonoBehaviour
{
    //Bradley Shepherd
    //14/05/2025


    public static CineCsmScript Instance;



    //SET UP Istructions

    //Place on emptyObject Named Camra Manager

    // The First cinemachine camera you using in the sceen need to fill both the CurrentActive Camera and MainCamera Filleds 
    //BOTH JUST NEED THE SAME CINEMACHINE CAMERA

    // The just use the function below to set off events using TIed in functoions 


    //when seting this system up you need fill both of these public Varible's with the fist cinemachine camera you are going to be using.
    public CinemachineVirtualCamera CurrentActiveCamera;
    public CinemachineVirtualCamera MainCamera;



    public void Start()
    {
        Instance = this;
    }



    //This will change to the next camera by deactivating the current cinemachine camera and then activating the next camera.
    public void changeCamera(CinemachineVirtualCamera Camera)
    {
        if (CurrentActiveCamera != null)
        {
            CurrentActiveCamera.gameObject.SetActive(false);
        }

        CurrentActiveCamera = Camera;
        CurrentActiveCamera.gameObject.SetActive(true);
        Camera.LookAt = null;
    }




    //FOR THE TWO Functions BELOW 
    // if you need use them on an event create a Function Like This.

    /*
    public CinemachineVirtualCamera FocusOnCarStickerCam;
    public Transform Target;

    public void FocusOnCarSticker()
    {
        ChangeToFocusedCamera(FocusOnCarStickerCam, Target);
    }*/

    //AND That should work perfectly fine

    
    //This will change the camera but will also make use of the camera lookat function to focus on certain objects
    public void ChangeToFocusedCamera(CinemachineVirtualCamera Camera, Transform Target)
    {
        changeCamera(Camera);

        CurrentActiveCamera.LookAt = Target;

    }

    //This can be used to change the lookAt function on camera 
    public void ChangeTarget(CinemachineVirtualCamera Camera, Transform Target)
    {

        CurrentActiveCamera.LookAt = Target.transform;

    }
}
