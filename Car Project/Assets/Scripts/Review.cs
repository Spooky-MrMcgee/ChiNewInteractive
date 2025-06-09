using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Review : MonoBehaviour
{
    [Header("Checks")]
    [SerializeField] PersistentVariables persistentVariables;
    [SerializeField] FailureTracker failureTracker;

    [Header("UI")]
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI failureText;
    [SerializeField] TextMeshProUGUI failureList;
    [SerializeField] TextMeshProUGUI timeTaken;
    [SerializeField] string successText;
    [SerializeField] GameObject day1Button, day2Button, mainMenuButton, exitGameButton;


    public void StartReview()
    {
        StartCoroutine(DoReview());
    }

    public IEnumerator DoReview()
    {
        int failureAmount = failureTracker.CheckFailures();
        failureText.text = "Faults: " + failureAmount + "/5";
        int minutes = Mathf.FloorToInt(failureTracker.timeTaken / 60);
        int seconds = Mathf.FloorToInt(failureTracker.timeTaken % 60);
        timeTaken.text = minutes.ToString() + ":" + seconds.ToString();
        foreach (string failureReason in failureTracker.failureReasons)
        {
            failureList.text += "<br>" + failureReason;
        }
        failureList.text += "<br><br>Unfortunately you have made some errors during this assessment, we advise either returning to Day 1 to refresh your knowledge or repeating the test for a better result!";
        if (failureTracker.CheckFailures() == 0)
        {
            failureList.text = successText;
            day1Button.SetActive(false);
            day2Button.SetActive(false);
            mainMenuButton.SetActive(true);
            exitGameButton.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        panel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
