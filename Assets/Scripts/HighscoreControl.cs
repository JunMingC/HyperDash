using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreControl : MonoBehaviour
{
    [NonSerialized]    public List<int> highScore;
    public Text highscore_1;
    public Text highscore_2;
    public Text highscore_3;
    public Text highscore_4;
    public Text highscore_5;
    public Text highscore_6;
    public Text highscore_7;
    public Text highscore_8;
    public Text highscore_9;
    public Text highscore_10;

    private void Start()
    {
        highScore = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            string tempString = "highscore" + (i + 1).ToString();
            highScore.Add(PlayerPrefs.GetInt(tempString, 0));
        }

        highscore_1.text = highScore[0].ToString();
        highscore_2.text = highScore[1].ToString();
        highscore_3.text = highScore[2].ToString();
        highscore_4.text = highScore[3].ToString();
        highscore_5.text = highScore[4].ToString();
        highscore_6.text = highScore[5].ToString();
        highscore_7.text = highScore[6].ToString();
        highscore_8.text = highScore[7].ToString();
        highscore_9.text = highScore[8].ToString();
        highscore_10.text = highScore[9].ToString();
    }

    public void SetHighScore(int tempScore)
    {
        for (int i = 0; i < highScore.Count; i++)
        {
            if(highScore[i] < tempScore)
            {
                highScore.RemoveAt(highScore.Count - 1);
                highScore.Insert(i, tempScore);
                break;
            }
        }

        for (int i = 0; i < highScore.Count; i++)
        {
            string tempString = "highscore" + (i + 1).ToString();
            PlayerPrefs.SetInt(tempString, highScore[i]);
        }
    }
}
