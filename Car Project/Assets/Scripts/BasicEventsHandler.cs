using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
public class BasicEventsHandler : MonoBehaviour
{ 
    public void DisplayImage(Image image)
    {
        image.enabled = true;
    }

    public void HideImage(Image image)
    {
        image.enabled = false;
    }

    public void AssignCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void Continue(int ID)
    {
        Instructional_Text.Instance.InstructionalText[Instructional_Text.Instance.TextId-1].CanContine = true;
        Instructional_Text.Instance.SetButton(ID);
    }
    public void HideAnswers()
    {
        Instructional_Text.Instance.answerBox1.SetActive(false);
        Instructional_Text.Instance.answerBox2.SetActive(false);
        Instructional_Text.Instance.answerBox3.SetActive(false);
    }

    public void EnableInteractable(InteractableObject interactableObject)
    {
        interactableObject.enabled = true;
    }

    public void DisableInteractable(InteractableObject interactableObject)
    {
        interactableObject.gameObject.layer = 0;
        interactableObject.enabled = false;
    }

    public void UpdateVCam(GameObject virtualCamera)
    {
        if (!virtualCamera.activeSelf)
            virtualCamera.SetActive(true);
        else if (virtualCamera.activeSelf)
            virtualCamera.SetActive(false);
    }

    public void PlayAnimation(Animator animator)
    {
        animator.SetTrigger("PlayAnimation");
    }
}
