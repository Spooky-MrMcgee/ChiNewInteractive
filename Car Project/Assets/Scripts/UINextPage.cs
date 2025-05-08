using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UINextPage : MonoBehaviour
{
    [SerializeField] List<GameObject> panels = new List<GameObject>();
    [SerializeField] int panelIndicator;

    public void NextSlide()
    {
        panelIndicator += 1;
        for (int x = 0; x <= panels.Count - 1; x++)
        {
            if (panelIndicator > panels.Count - 1)
                return;

            Debug.Log("Iterating now");
            if (panels[x].activeSelf == false && x == panelIndicator)
            {
                panels[x].SetActive(true);
            }
            else
            {
                panels[x].SetActive(false);
            }
        }
    }
}
