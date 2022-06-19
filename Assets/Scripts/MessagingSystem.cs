using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingSystem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI tmp;
    private float t = 0;

    public void Message(string msg)
    {
        tmp.text = msg;
        tmp.gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    public void Update()
    {
        if(tmp.gameObject.GetComponent<RectTransform>().localScale == Vector3.one){
            t += Time.deltaTime;
            if(t >= 3){
                tmp.gameObject.GetComponent<RectTransform>().localScale = Vector3.zero;
                t = 0;
            }
        }
        
    }
}
