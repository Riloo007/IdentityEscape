using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingSystem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI tmp;
    public RectTransform Container;
    private bool Open;
    private float t = 0;

    public void Message(string msg)
    {
        tmp.text = msg;
        tmp.gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
        Open = true;
        t = 0;
    }

    public void Update()
    {
        if(Open){
            t += Time.deltaTime;
            if(t >= 3){t = 0; Open = false;}
            Container.localScale += new Vector3(0f, Time.deltaTime * 5, 0f);
            if(Container.localScale.y >= 1f){
                Container.localScale = Vector3.one;
            }
        }else{
            Container.localScale -= new Vector3(0f, Time.deltaTime * 5, 0f);
            if(Container.localScale.y <= 0){
                Container.localScale = new Vector3(1f, 0f, 1f);
            }
        }   
    }
}
