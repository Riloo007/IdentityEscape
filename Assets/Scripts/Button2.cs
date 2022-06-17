using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour , Action
{
    public playerControl player;
    public bool pressed = false;
    public Animator camAnim;
    public Camera cutCam;
    public Canvas UI;
    
    public void Interact()
    {
    	if(!pressed) {
            pressed = true;
            transform.position -= new Vector3(0f, 0.2f, 0f);
            cutCam.enabled = true;
            camAnim.SetTrigger("Start");
            player.enabled = false;
            UI.enabled = false;
        }
    }

    public void Update()
    {
        if(!player.enabled && !cutCam.enabled)
        {
            player.enabled = true;
            transform.position += new Vector3(0f, 0.2f, 0f);
            pressed = false;
            camAnim.ResetTrigger("Start");
            UI.enabled = true;
        }
    }
}
