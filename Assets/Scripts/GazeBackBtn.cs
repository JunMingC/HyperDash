using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeBackBtn : MonoBehaviour
{
    public Image mask_image;
    public float gazeTimer;
    public GameObject highscoreCanvas;
    public GameObject startBtn;
    public GameObject tutorialBtn;
    public GameObject highscoreBtn;

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
                highscoreCanvas.SetActive(false);
                startBtn.SetActive(true);
                tutorialBtn.SetActive(true);
                highscoreBtn.SetActive(true);
                timer = gazeTimer;
            }
            else
            {
                timer -= Time.deltaTime;
                mask_image.fillAmount += 0.5f * Time.deltaTime;
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
