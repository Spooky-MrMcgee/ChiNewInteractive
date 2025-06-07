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
    private bool canSkip = false;
    private bool skip = false;

    [Header("Instructional Holder")]
    public GameObject InstructinalHolder;

    [Header("Questions UI")]
    public TextMeshProUGUI answerText1;
    public TextMeshProUGUI answerText2;
    public TextMeshProUGUI answerText3;    
    public Button InteractionButton;
    public GameObject answerBox1;
    public GameObject answerBox2;
    public GameObject answerBox3;

    [Header("Hint UI")]
    public GameObject HintsButton;
    public GameObject HintsTextBox;


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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
             if (canSkip)
            {
                skip = true;
            }
        }
    }


    //This will set up the next Buttion Id 
    public void SetButton(int InstructionalTextID)
    {
        TextId = InstructionalTextID;
    }

    public void hideInstructionalText()
    {
        InstructinalHolder.SetActive(false);
    }



    public void ShowInstructional(int inputID)
    {

        if(InstructinalHolder.activeSelf == false)
        {
            InstructinalHolder.SetActive(true);
        }
        
        if(HintsButton.activeSelf == true)
        {
            HintsButton.SetActive(false);
        }
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
        if (InstructionalText[InstructionalTextID].RemoveHint)
        {
            HintsTextBox.SetActive(false);
        }
        InteractionButton.gameObject.SetActive(false);
        StartCoroutine(DisplayLine(InstructionalText[InstructionalTextID].InfoText));
    }

    private IEnumerator DisplayLine(string line)
    {
   


        Text.text = "";

        CanContineToNextLine = false;

        bool isAddingRickTextTag = false;

        int CharUsed = 0;

        foreach (char Letter in line.ToCharArray())
        {
            //I could create a custom tag for events needed during dialogue by create a custom rich tage checking for it spelling in the if statment an using that to fire events

            CharUsed += 1;


            if (CharUsed >= 3)
            {
                canSkip = true;
            }

            if (skip)
            {

                Text.text = line;
                skip = false;
                break;
            }

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

        canSkip = false;

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

            HintsButton.SetActive(true);
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


    public bool RemoveHint;
    [TextArea(15, 20)]
    public string HintToDisplay;

}
