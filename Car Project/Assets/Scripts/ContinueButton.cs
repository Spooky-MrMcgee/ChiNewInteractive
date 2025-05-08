using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour, IInteractable
{
    [SerializeField] UINextPage UIHandler;

    public void Interact()
    {
        Debug.Log("Interacting here");
        UIHandler.NextSlide();
    }
}
