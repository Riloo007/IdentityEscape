using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBig : MonoBehaviour , Action
{
    private float scale;
    private bool growing = false;

    public void Update()
    {
        if(growing)
        {
            scale += 1f * Time.deltaTime;
            transform.localScale = Vector3.one * scale;
        }
    }

    public void Interact()
    {
        growing = true;
    }
}
