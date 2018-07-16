﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialInstruction2 : MonoBehaviour
{
    public GameObject vrCamera;
    public GameObject player;
    public TutorialControl tutorialControl;
    public Text main_text;
    public Image mask_image;
    public float gazeTimer;
    public bool inCameraView;

    private float timer;
    private bool updateGaze;
    private bool animateCanvas;

    private void OnEnable()
    {

        mask_image.fillAmount = 0;
        updateGaze = false;
        timer = gazeTimer;
        transform.position = vrCamera.transform.position + vrCamera.transform.right;
    }

    private void Update()
    {
        gazeMenu();
        animateMenu();
    }


    private void animateMenu()
    {
        if (!inCameraView)
        {
            animateCanvas = true;

        }

        if (animateCanvas)
        {
            Vector3 target = vrCamera.transform.position + vrCamera.transform.forward;
            target.y = player.transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);
            transform.LookAt(player.transform);

            if (transform.position == target)
            {
                animateCanvas = false;
            }
        }
    }

    private void gazeMenu()
    {
        if (updateGaze)
        {
            if (timer < 0)
            {
                tutorialControl.spawn_menu_3();
                gameObject.SetActive(false);
            }
            else
            {
                timer -= Time.deltaTime;
                mask_image.fillAmount += 0.25f * Time.deltaTime;
            }
        }
        else
        {
            mask_image.fillAmount = 0;
            timer = gazeTimer;
        }
    }

    public void gazed(bool GazedAt)
    {
        updateGaze = GazedAt;
    }
}
