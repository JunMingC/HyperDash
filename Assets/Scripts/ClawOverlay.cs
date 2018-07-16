using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawOverlay : MonoBehaviour
{
    public GameObject vrCamera;

    private bool forward;
    private bool backward;
    private float animationSpeed;

    private void Start()
    {
        transform.position = vrCamera.transform.position + vrCamera.transform.forward * -4.3f;
        forward = false;
        backward = false;
    }

    private void Update()
    {
        if (TimeControl.timeHealth > 0)
        {
            animateClaw();
        }
    }

    private void animateClaw()
    {
        if (forward)
        {
            transform.position = Vector3.MoveTowards(transform.position, vrCamera.transform.position + vrCamera.transform.forward * -2f, animationSpeed);
        }
        if (backward)
        {
            transform.position = Vector3.MoveTowards(transform.position, vrCamera.transform.position + vrCamera.transform.forward * -4.3f, animationSpeed);
        }
    }

    public void animateForward(float spd)
    {
        animationSpeed = spd;
        forward = true;
        backward = false;
    }

    public void animateBackward(float spd)
    {
        animationSpeed = spd;
        forward = false;
        backward = true;
    }
}
