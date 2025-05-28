using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //This is the Manager used for taking in the scoring information for givingthe player score
    List<Check> Checks = new List<Check>();

    public GameObject AnswerSheet;
    public GameObject AnswerPrefab;
    public GameObject ScorePrefab;

    public void MarkCorrect(int checkID)
    {
        Checks[checkID].Correct = true;
    }


    public void ShowAnswerSheet()
    {

        int marks = 0;
        var answerSheetPrefab = Instantiate(AnswerSheet);


        foreach (var check in Checks)
        {
             var answer = Instantiate(AnswerPrefab, answerSheetPrefab.transform.position, Quaternion.identity, answerSheetPrefab.transform);

            if (check.Correct)
            {
                marks++;
                
            }
            else
            {

            }
        }

        var Score = Instantiate(ScorePrefab, answerSheetPrefab.transform.position, Quaternion.identity, answerSheetPrefab.transform);

    }

}

public class Check
{

    //by default these are set to false and change to correct when the player takes an action so missed action are labled as faults 
    public bool Correct = false;

    [TextArea(15, 20)]
    public string CorrectInfoText;
    [TextArea(15, 20)]
    public string FailedInfoText;

    public string RetriveText()
    {
        if (Correct)
        {
            return CorrectInfoText;
        }
        else
        {
            return FailedInfoText;
        }
    }

}
