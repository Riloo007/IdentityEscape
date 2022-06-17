using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour , Action
{
    public bool pressed = false;
    public Animator animator;
    
    public void Interact()
    {
    	if(pressed) {pressed = false; transform.position += new Vector3(0f, 0.2f, 0f); animator.SetBool("playing", false);}
    	else{pressed = true; transform.position -= new Vector3(0f, 0.2f, 0f); animator.SetBool("playing", true);}
    }
}
