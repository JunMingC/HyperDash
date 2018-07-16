using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeStartBtn : MonoBehaviour
{
    public Image mask_image;
    public float gazeTimer;
    public LevelControl levelControl;

    private float timer;
    private bool updateGaze;

    private void OnEnable()
    {
        mask_image.fillAmount = 0;
        updateGaze = false;
        timer = gazeTimer;

    }

    private void Update()
    {
        if (TimeControl.timeHealth > 0)
        {
            gazeMenu();
        }
    }

    private void gazeMenu()
    {
        if (updateGaze)
        {
            if (timer < 0)
            {
                levelControl.StartGame();
                timer = gazeTimer;
            }
            else
            {
                timer -= Time.deltaTime;
                mask_image.fillAmount += 0.33f * Time.deltaTime;
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
