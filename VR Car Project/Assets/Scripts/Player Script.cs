using UnityEngine;
using System.Collections;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] Transform mainView;
    [SerializeField] HandScript leftHand, rightHand;
    bool rotated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftHand.thumbstickUp)
            transform.position += transform.forward;
        if (leftHand.thumbstickDown)
            transform.position += -transform.forward;
        if (leftHand.thumbstickRight)
            transform.position += transform.right;
        if (leftHand.thumbstickLeft)
            transform.position += -transform.right;

        if (rightHand.thumbstickLeft)
        {
            if (rotated)
                return;
            mainView.transform.rotation = new Quaternion(mainView.transform.rotation.x, mainView.transform.rotation.y + 20, mainView.transform.rotation.z, mainView.transform.rotation.w);
            StartCoroutine(RotationCooldown());
        }
        if (rightHand.thumbstickRight)
        {
            if (rotated)
                return;
            mainView.transform.rotation = new Quaternion(mainView.transform.rotation.x, mainView.transform.rotation.y - 20, mainView.transform.rotation.z, mainView.transform.rotation.w);
            StartCoroutine(RotationCooldown());
        }

    }

    IEnumerator RotationCooldown()
    {
        rotated = true;
        yield return new WaitForSeconds(0.5f);
        rotated = false;
    }
    
}
