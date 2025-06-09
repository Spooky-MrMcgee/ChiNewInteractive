using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverUI : MonoBehaviour
{
    public void Display(GameObject UIEnable)
    {
        UIEnable.SetActive(true);
    }

    public void Hide(GameObject UIEnable)
    {
        UIEnable.SetActive(false);
    }
}
