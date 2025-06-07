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
    public float timeLimit;
    public UnityEvent mouseDownEvent;
    float time;
    bool button;
    public Animator animator;

    private void OnDisable()
    {
        this.gameObject.layer = 0;
    }
    private void OnMouseOver()
    {
        if (this.enabled == false)
            return;
        this.gameObject.layer = 3;

        if (!mouseDown)
            return;

        if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;
            if (!animator.GetBool("PlayAnimation"))
                animator.SetBool("PlayAnimation", true);
        }
        else
        {
            if (animator.GetBool("PlayAnimation"))
                animator.SetBool("PlayAnimation", false);
            time = 0f;
        }

        if (time >= timeLimit)
        {
            mouseDownEvent.Invoke();
            time = 0f;
            this.gameObject.layer = 0;
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
