using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFall : MonoBehaviour , Action
{
    // Start is called before the first frame update
    public void Interact()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
