using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject vrCamera;
    public GameObject player;
    public bool inCameraView;

    private bool animateCanvas;

    private void Start()
    {
        transform.position = vrCamera.transform.position + vrCamera.transform.right;
    }

    private void Update()
    {
        if (TimeControl.timeHealth > 0)
        {
            animateMenu();
        }
    }

    private void animateMenu()
    {
        if(!inCameraView)
        {
            animateCanvas = true;

        }

        if(animateCanvas)
        {
            Vector3 target = vrCamera.transform.position + vrCamera.transform.forward;
            target.y = player.transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);
            transform.LookAt(player.transform);

            if(transform.position == target)
            {
                animateCanvas = false;
            }
        }
    }
}
