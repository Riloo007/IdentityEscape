using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLight : MonoBehaviour
{
    public AnimationCurve intensity;
    public float speed = 1;

    private float time;
    private Light spot;
    private Vector3 startPos;

    void Start() {spot = gameObject.GetComponent<Light>(); startPos = transform.position; Debug.Log(startPos);}

    void Update()
    {
        time += speed * Time.deltaTime;
        if(time >= intensity[intensity.keys.Length-1].time) {time = time - intensity[intensity.keys.Length -1].time;}
        spot.intensity = intensity.Evaluate(time) * 4 + 9f;
        transform.position = startPos + (Vector3.one * intensity.Evaluate(time) / 10);
    }
}
