using UnityEngine;

public class HandScript : MonoBehaviour
{
    public bool isLeft;
    public bool isGrabbing;
    public bool isPullingTrigger;
    public bool thumbstickUp;
    public bool thumbstickDown;
    public bool thumbstickRight;
    public bool thumbstickLeft;
    public Transform gripPoint;
    public bool isHolding;
    public GameObject model;
    [SerializeField] GameObject hand;
    public GameObject objectHeld;
  

    // Update is called once per frame
    void Update()
    {
        isGrabbing = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, GetControllerType() );
        isPullingTrigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, GetControllerType());
        thumbstickUp = OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, GetControllerType());
        thumbstickDown = OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, GetControllerType());
        thumbstickLeft = OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, GetControllerType());
        thumbstickRight = OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, GetControllerType());
    }


    //This defines which controller is being used (Left / Right ) Based on input.
    public OVRInput.Controller GetControllerType()
    {
        if (isLeft)
        {
            return OVRInput.Controller.LTouch;
        }
        else
        {
            return OVRInput.Controller.RTouch;
        }
    }

    public void HideHand()
    {

        model.GetComponent<Renderer>().enabled = false;
    }

    public void ShowHand()
    {
        model.GetComponent<Renderer>().enabled = true;
    }
}
