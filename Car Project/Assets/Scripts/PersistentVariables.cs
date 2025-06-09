using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentVariables : MonoBehaviour
{
    public static PersistentVariables instance;
    public int pressure;
    public int failures;
    public int hintsUsed;
    public bool dayTutorial;

    private void Awake()
    {
        instance = this;
        pressure = 25;
        failures = 0;
        hintsUsed = 0;
    }
    public void IncreasePressureScore(int increase)
    {
        pressure += increase;
    }

    public void DecreasePressureScore(int increase)
    {
        pressure -= increase;
    }

    public void IncreaseFailureScore(int increase)
    {
        failures += increase;
    }

    public void DecreaseFailureScore(int increase)
    {
        failures -= increase;
    }

    public void IncreaseHintsScore(int increase)
    {
        hintsUsed += increase;
    }

    public void DecreaseHintsScore(int increase)
    {
        hintsUsed -= increase;
    }
}
