using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLight : MonoBehaviour
{
    public AnimationCurve intensity;
    public float speed = 1;

    private float time;
    private Light spot;

    void Start() {spot = gameObject.GetComponent<Light>();}

    void Update()
    {
        time += speed * Time.deltaTime;
        if(time >= intensity[intensity.keys.Length-1].time) {time = time - intensity[intensity.keys.Length -1].time;}
        spot.intensity = intensity.Evaluate(time) + 9f;
    }
}
