using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L01_Door : MonoBehaviour , Action
{
    public MessagingSystem msg;

    public void Interact()
    {
        msg.Message("It's Locked.");
    }
}
