using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [NonSerialized]    public int maxEnemy;

    public GameObject player;
    public GameObject vrCamera;
    public GameObject comboText;
    public bool DeleteKeys;
    public int limitEnemy;
    public float rabbitRate;
    public GameObject cockPit;
    public HudControl hudControl;
    public MenuControl menuControl;
    public LoseControl loseControl;
    public PlayerControl playerControl;
    public HighscoreControl highscoreControl;
    public GameObject shipMenu;

    private int levelScore;
    private bool updateLose;

    private void Start()
    {
        if(DeleteKeys)
        {
            PlayerPrefs.DeleteAll();
        }

        updateLose = true;
        levelScore = 100;
        cockPit.gameObject.SetActive(false);
        hudControl.gameObject.SetActive(false);
        menuControl.gameObject.SetActive(true);
        loseControl.gameObject.SetActive(false);
        shipMenu.gameObject.SetActive(false);
        //Invoke("adjustShip", 0.1f);
    }

    private void Update()
    {
        if (playerControl.health <= 0 && updateLose)
        {
            loseControl.gameObject.SetActive(true);
            comboText.SetActive(false);
            highscoreControl.SetHighScore(playerControl.score);
            updateLose = false;
        }

        if (TimeControl.timeHealth > 0)
        {
            levelProgress();
        }
    }

    private void adjustShip()
    {
        shipMenu.gameObject.SetActive(true);
        Vector3 target = vrCamera.transform.position + vrCamera.transform.forward * 4f + vrCamera.transform.right * 0.6f;
        target.y = player.transform.position.y;
        target += player.transform.up * 0.9f;
        shipMenu.transform.position = target;
        shipMenu.transform.LookAt(vrCamera.transform);
    }

    private void levelProgress()
    {
        if (playerControl.score >= levelScore && maxEnemy < limitEnemy)
        {
            levelScore *= 2;
            maxEnemy++;
            rabbitRate++;
        }
    }

    public void StartGame()
    {
        cockPit.gameObject.SetActive(true);
        hudControl.gameObject.SetActive(true);
        menuControl.gameObject.SetActive(false);
        loseControl.gameObject.SetActive(false);
        shipMenu.gameObject.SetActive(false);
        levelScore = 100;
        maxEnemy = 4;
    }
}
