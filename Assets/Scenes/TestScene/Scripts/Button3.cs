using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour , Action
{
    public MessagingSystem msg;

    public void Interact()
    {
        msg.Message("Hey, this is an In-Game Message!");
    }
}
