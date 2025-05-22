using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent unityEvent;
    public bool mouseDown;
    public UnityEvent mouseDownEvent;
    float time;
    private void OnMouseOver()
    {
        if (this.enabled == false)
            return;
        this.gameObject.layer = 3;

        if (!mouseDown)
            return;

        if (Input.GetMouseButton(0))
            time += Time.deltaTime;
        else
            time = 0f;

        if (time >= 3f)
        {
            mouseDownEvent.Invoke();
            time = 0f;
            this.enabled = false;
        }
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

    public void EnableMouseOver()
    {
        mouseDown = true;
    }

    public void DisableMouseOver()
    {
        mouseDown = false;
    }

    
}
