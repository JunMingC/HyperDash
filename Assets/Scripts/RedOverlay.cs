using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedOverlay : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool animate;
    private float animationDuration;

    private void Start()
    {
        initialPosition = transform.localPosition;
        transform.position = transform.position + transform.up * 0.7f;
    }

    private void Update()
    {
        if (TimeControl.timeHealth > 0)
        {
            animateRed();
        }
    }

    private void animateRed()
    {
        if (animate)
        {
            if (animationDuration > Time.time)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 0.2f);
            }
            else
            {
                animate = false;
            }
        }
    }

    public void startAnimate()
    {
        transform.localPosition = initialPosition;
        animationDuration = Time.time + 4f;
        animate = true;
    }
}
