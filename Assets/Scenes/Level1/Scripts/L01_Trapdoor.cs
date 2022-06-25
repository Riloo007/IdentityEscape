using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L01_Trapdoor : MonoBehaviour , Action
{
    public MessagingSystem msg;
    public List<string> messages;
    private int counter;

    public void Interact()
    {
        if(messages.Count > counter){counter += 1;}
        msg.Message(messages[counter - 1]);
    }
}
