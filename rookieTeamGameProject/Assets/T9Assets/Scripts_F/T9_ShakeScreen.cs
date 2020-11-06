using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T9_ShakeScreen : MonoBehaviour
{
    private Transform transformCam;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1f;

    private Vector3 initialPosition;

    private void Awake()
    {
        transformCam = Camera.main.transform;
        initialPosition = transformCam.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shakeDuration > 0f)
        {
            transformCam.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transformCam.localPosition = initialPosition;
        }
    }

    public void Shake(float _duration = 1f, float _magnitude = 0.7f)
    {
        shakeDuration = _duration;
        shakeMagnitude = _magnitude;
    }
}
