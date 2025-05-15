using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent unityEvent;
    private void OnMouseOver()
    {
        if (this.enabled == false)
            return;
        this.gameObject.layer = 3;
    }

    private void OnMouseExit()
    {
        if (this.enabled == false)
            return;
        this.gameObject.layer = 0;
    }

    private void OnMouseUpAsButton()
    {
        if (this.enabled == false)
            return;
        unityEvent.Invoke();
    }

    
}
