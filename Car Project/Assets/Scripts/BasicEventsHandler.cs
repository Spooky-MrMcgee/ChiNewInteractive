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

    public void NewUpdateVCam(CinemachineVirtualCamera virtualCamera)
    {
        if(CineCsmScript.Instance != null)
        {
            CineCsmScript.Instance.changeCamera(virtualCamera);
        }
       
    }

    public void UpdateQuestionTextEventOne(int value)
    {
        Debug.Log("AAA");
        Button questionButton = Instructional_Text.Instance.answerBox1.GetComponent<Button>();
        questionButton.onClick.RemoveAllListeners();
        questionButton.onClick.AddListener(delegate{Instructional_Text.Instance.ShowInstructional(value);});
        questionButton.onClick.AddListener(delegate{HideAnswers();});
    }

    public void UpdateQuestionTextEventTwo(int value)
    {
        Button questionButton = Instructional_Text.Instance.answerBox2.GetComponent<Button>();
        questionButton.onClick.RemoveAllListeners();
        questionButton.onClick.AddListener(delegate{Instructional_Text.Instance.ShowInstructional(value);});
        questionButton.onClick.AddListener(delegate{HideAnswers();});
    }

    public void UpdateQuestionTextEventThree(int value)
    {
        Button questionButton = Instructional_Text.Instance.answerBox3.GetComponent<Button>();
        questionButton.onClick.RemoveAllListeners();
        questionButton.onClick.AddListener(delegate{Instructional_Text.Instance.ShowInstructional(value);});
        questionButton.onClick.AddListener(delegate{HideAnswers();});
    }

    public void PlayAnimation(Animator animator)
    {
        animator.SetTrigger("PlayAnimation");
    }
}
