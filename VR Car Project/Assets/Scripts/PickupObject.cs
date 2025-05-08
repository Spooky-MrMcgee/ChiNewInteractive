using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private bool Highlight;
    Material mat;
    public bool canPickUp, hideHand;
    public HandScript activeHand;

    private void Update()
    {
        if (activeHand)
        {
            if (canPickUp)
            {
                if (activeHand.isGrabbing && canPickUp == true)
                {
                    activeHand.isHolding = true;
                    if (hideHand)
                        activeHand.HideHand();
                }
                if (!activeHand.isGrabbing || canPickUp == false)
                {
                    activeHand.isHolding = false;
                    if (hideHand)
                        activeHand.ShowHand();
                }
                    
                if (activeHand.isHolding)
                {
                    activeHand.objectHeld = this.gameObject;
                    transform.parent = activeHand.gripPoint;
                }
                else
                {
                    activeHand.objectHeld = null;
                    transform.parent = null;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canPickUp = true;
        Debug.Log(other.name);
        if (!canPickUp)
            return;

        if (activeHand != null)
            return;

        var hand = other.gameObject.GetComponentInParent<HandScript>();
        if(hand != null)
        {
            if (hand.isHolding)
                return;

            print("Hand Entered 2");

            activeHand = hand;
            Debug.Log("Current hand is active hand");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canPickUp = false;
        if (canPickUp)
            return;

        if (activeHand == null)
            return;

        var hand = other.gameObject.GetComponentInParent<HandScript>();

        if (hand != null)
        {
            if (hand.isHolding)
                return;

            print("Hand Entered 2");

            activeHand = null;
            Debug.Log("Current hand is active hand");
        }
    }
}
