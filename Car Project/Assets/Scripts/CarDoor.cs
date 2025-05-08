using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDoor : MonoBehaviour, IInteractable
{
    [SerializeField] Animator carDoorAnim;
    public void Interact()
    {
        carDoorAnim.SetTrigger("Interacted");
    }
}
