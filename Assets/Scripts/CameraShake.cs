using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float power = 0.1f;
    private float duration = 0.3f;
    private Transform camera;
    private float slowDownAmount = 1f;
    public bool shouldShake = false;

    private Vector3 startPos;
    private float initialDuration;
    void Start()
    {
        camera = Camera.main.transform;
        startPos = camera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if (duration > 0)
            {
                camera.localPosition = startPos + Random.insideUnitSphere*power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPos;
            }
        }
    }
}
