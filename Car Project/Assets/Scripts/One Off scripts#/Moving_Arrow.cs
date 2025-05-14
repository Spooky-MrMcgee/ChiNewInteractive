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

        Vector3 startpos = localpos.transform.position;

        transform.position = startpos + transform.up * Mathf.Sin(Time.time * Frequincy) * magnutuide;
    }

}

 
