using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudControl : MonoBehaviour
{
    public PlayerControl playerControl;
    public Text score_text;
    public Text combo_text;

    private float comboAnimate;

    private void Start()
    {
        comboAnimate = 1f;
    }

    private void Update()
    {
        updateHud();
    }

    private void updateHud()
    {
        score_text.text = "Score: " + playerControl.score.ToString();

        if (playerControl.combo <= 0)
        {
            combo_text.enabled = false;
        }
        else
        {
            combo_text.enabled = true;
        }

        if (combo_text.text != "Combo: " + playerControl.combo.ToString())
        {

            combo_text.text = "Combo: " + playerControl.combo.ToString();
            combo_text.fontSize = 36;

        }

        if (combo_text.fontSize > -1)
        {
            if (comboAnimate < 0)
            {
                combo_text.fontSize -= 1;
                comboAnimate = 1f;
            }
            else
            {
                comboAnimate -= Time.deltaTime * 1.5f;
            }
        }
    }
}
