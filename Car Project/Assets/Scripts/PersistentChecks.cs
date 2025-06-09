using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentChecks : MonoBehaviour
{
    PersistentVariables pv;
    [SerializeField] InteractableObject hose;
    void Start()
    {
        pv = PersistentVariables.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.pressure == 34 && pv.dayTutorial)
        {
            hose.enabled = true;
        }
    }
}
