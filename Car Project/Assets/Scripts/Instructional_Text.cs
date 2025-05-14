using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using Mono.Cecil.Cil;

public class Instructional_Text : MonoBehaviour
{
    public static Instructional_Text Instance;
    [Header("UI Elements")]
    public TextMeshProUGUI Text;
    public Button InteractionButton;

    [Header("Info Text")]
    public List<InText> InstructionalText = new List<InText>();

    //Text display
    private bool CanContineToNextLine = false;
    [SerializeField] float TypingSpeed = 0.04f;

    //Buttion SetUp
    public int TextId = 0;

    private void Start()
    {
        ShowInstructional(TextId);
    }

 

    //This will set up the next Buttion Id 
    public void setButtion(int InstructionalTextID)
    {
        TextId = InstructionalTextID;
    }

    public void ShowInstructional(int inputID)
    {
        if (inputID != 0)
        {
            inputID = TextId;
        }
        SetDisplayText(TextId);
        TextId++;
    }

    //This is not to be used a public function it just displayes the text
    private void SetDisplayText(int InstructionalTextID)
    {
        InteractionButton.gameObject.SetActive(false);
        StartCoroutine(DisplayLine(InstructionalText[InstructionalTextID].InfoText));
    }

    private IEnumerator DisplayLine(string line)
    {
   
        Text.text = "";

        CanContineToNextLine = false;

        bool isAddingRickTextTag = false;


        foreach (char Letter in line.ToCharArray())
        {
            //I could create a custom tag for events needed during dialogue by create a custom rich tage checking for it spelling in the if statment an using that to fire events

            //check for rich text tag
            if (Letter == '<' || isAddingRickTextTag)
            {
                isAddingRickTextTag = true;
                Text.text += Letter;
                if (Letter == '>')
                {
                    isAddingRickTextTag = false;
                }
            }
            else
            {
                Text.text += Letter;
                yield return new WaitForSeconds(TypingSpeed);
            }


        }

        CanContineToNextLine = true;

    
        if (InstructionalText[TextId-1].CanContine)
        {
            InteractionButton.gameObject.SetActive(true);
        }

    
        InstructionalText[TextId-1].Events.Invoke();
            
        


    }



}

[System.Serializable]
public class InText
{
    [TextArea(15, 20)]
    public string InfoText;
    public UnityEvent Events;

    public bool CanContine = false;

}
