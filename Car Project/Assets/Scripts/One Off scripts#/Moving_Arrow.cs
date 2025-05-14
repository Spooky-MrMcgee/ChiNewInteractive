using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Arrow : MonoBehaviour
{

    Transform localpos;

    public float magnutuide;
    public float Frequincy;
    private float Ypos;

    private void OnEnable()
    {
        localpos = GetComponent<RectTransform>();
    }

    private void Update()
    {

        var baseY = localpos.transform.position.y;
        Ypos = Mathf.Sin(Time.deltaTime * Frequincy) * magnutuide;
        var newY = baseY + Ypos; 
        localpos.transform.position = new Vector3(localpos.transform.position.x, newY, localpos.transform.position.z);
    }

}

 
