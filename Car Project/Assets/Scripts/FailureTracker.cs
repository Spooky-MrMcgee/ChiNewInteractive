using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureTracker : MonoBehaviour
{
    [Header("Failure Strings")]
    public List<string> failureReasons = new List<string>();
    public string fiveMinutesFail;
    public string noGlovesFail;
    public string checkTyreOrEngineFail;
    public string incorrectPSIFail;
    public string overfillFail;
    public float timeTaken;
    [Header("Failure Checks")]
    public bool noFiveMinutes;
    public bool noGloves;
    public bool checkWheelOrEngineForPressure;
    public bool incorrectPSI;
    public bool overfill;

    [Header("Other Checks")]
    public bool doorChecked;
    public bool carInteractedWith;
    public PersistentVariables persistentVariables;

    void Start()
    {
        noFiveMinutes = true;
        noGloves = true;
        checkWheelOrEngineForPressure = false;
        incorrectPSI = false;
        overfill = false;
        doorChecked = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeTaken += Time.deltaTime;
    }

    public int CheckFailures()
    {
        if (noFiveMinutes)
        {
            persistentVariables.IncreaseFailureScore(1);
            failureReasons.Add(fiveMinutesFail);
        }

        if (noGloves)
        {
            persistentVariables.IncreaseFailureScore(1);
            failureReasons.Add(noGlovesFail);
        }

        if (checkWheelOrEngineForPressure)
        {
            persistentVariables.IncreaseFailureScore(1);
            failureReasons.Add(checkTyreOrEngineFail);
        }

        if (incorrectPSI)
        {
            persistentVariables.IncreaseFailureScore(1);
            failureReasons.Add(incorrectPSIFail);
        }

        if (overfill)
        {
            persistentVariables.IncreaseFailureScore(1);
            failureReasons.Add(overfillFail);
        }

        return persistentVariables.failures;
    }

    public void CheckGloves()
    {
        if (!noGloves)
            return;

        if (carInteractedWith)
            noGloves = true;
    }

    public void CheckTime()
    {
        if (!noFiveMinutes)
            return;

        if (carInteractedWith)
            noFiveMinutes = true;
    }

    public void CheckLabel()
    {
        if (!doorChecked)
            checkWheelOrEngineForPressure = true;
    }

    public void PressureCheck()
    {
        if (persistentVariables.pressure != 34)
        {
            incorrectPSI = true;
        }
        else
        {
            incorrectPSI = false;
        }
    }

    public void OverfillCheck()
    {

    }

    public void DoorCheck(bool check)
    {
        doorChecked = check;
    }

    public void TimeCheck(bool check)
    {
        noFiveMinutes = check;
    }

    public void GlovesCheck(bool check)
    {
        noGloves = check;
    }

    public void CarInteractionCheck(bool check)
    {
        carInteractedWith = check;
    }

    public void AddFailureString(string failureString)
    {
        failureReasons.Add(failureString);
    }
}
