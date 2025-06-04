using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TirePressureNumber : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    void Update()
    {
        text.text = PersistentVariables.instance.pressure.ToString();
    }
}
