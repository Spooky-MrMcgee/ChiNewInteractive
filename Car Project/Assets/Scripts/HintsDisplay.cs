using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HintsDisplay : MonoBehaviour
{
    //Bradley Shepherd
    //15/05/2025

    
   
    public TextMeshProUGUI HintText;


    public void ShowHint()
    {
        Instructional_Text.Instance.HintsButton.SetActive(false);
        Instructional_Text.Instance.HintsTextBox.SetActive(true);
        int CurrentID = Instructional_Text.Instance.TextId;
        HintText.text = Instructional_Text.Instance.InstructionalText[CurrentID - 1].HintToDisplay;
    }

    public void HideHint()
    {
        Instructional_Text.Instance.HintsTextBox.SetActive(false);
        HintText.text = "";
    }


}
