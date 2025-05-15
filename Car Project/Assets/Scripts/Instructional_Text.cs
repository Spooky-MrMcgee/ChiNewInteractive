using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using Unity.Collections;
using System.Linq;

public class Instructional_Text : MonoBehaviour
{
    public static Instructional_Text Instance;
    [Header("UI Elements")]
    public TextMeshProUGUI Text;
    public TextMeshProUGUI answerText1;
    public TextMeshProUGUI answerText2;
    public TextMeshProUGUI answerText3;    
    public Button InteractionButton;
    public GameObject answerBox1;
    public GameObject answerBox2;
    public GameObject answerBox3;

    [Header("Info Text")]
    public List<InText> InstructionalText = new List<InText>();

    //Text display
    private bool CanContineToNextLine = false;
    [SerializeField] float TypingSpeed = 0.04f;

    //Buttion SetUp
    public int TextId = 0;

    private void Start()
    {
        Instance = this;
        ShowInstructional(TextId);
    }

 

    //This will set up the next Buttion Id 
    public void SetButton(int InstructionalTextID)
    {
        TextId = InstructionalTextID;
    }

    public void ShowInstructional(int inputID)
    {
        if (inputID != 0)
        {
            TextId = inputID;
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

        if (InstructionalText[TextId-1].DisplayAnswers)
        {
            for(int x = 0; x <= InstructionalText[TextId-1].AnswersToDisplay.Length; x++)
            {
                if (x == 0)
                {
                    answerBox1.SetActive(true);
                    answerText1.text = InstructionalText[TextId-1].AnswersToDisplay[x];
                }
                if (x == 1)
                {
                    answerBox2.SetActive(true);
                    answerText2.text = InstructionalText[TextId-1].AnswersToDisplay[x];
                }
                if (x == 2)
                {
                    answerBox3.SetActive(true);
                    answerText3.text = InstructionalText[TextId-1].AnswersToDisplay[x];
                }
            }
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
    public string[] AnswersToDisplay;
    public bool DisplayAnswers;

}
