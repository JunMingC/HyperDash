using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPlayer : MonoBehaviour
{
    public TutorialControl tutorialControl;
    public ClawOverlay clawOverlay;
    public RedOverlay redOverlayTop;
    public RedOverlay redOverlayBot;
    public ParticleSystem particle_system;
    public AudioSource audioBgm;
    public AudioSource audioAmbient;
    public AudioSource audioSfx_success;
    public AudioSource audioSfx_explode;
    public AudioSource audioSfx_dash;
    public AudioClip monster_success;
    public AudioClip monster_explode;
    public AudioClip player_dash;
    public float attackRate;
    public float comboGap;
    public int health;
    public int score;
    public int combo;
    public Image reticle_mask;
    public List<Image> heartList;

    private float attackTimer;
    private float comboTimer;
    private float speed;
    private float fillDuration;
    private int lastHealth;
    public GameObject gazed;
    public GameObject target;

    private void Start()
    {
        attackTimer = attackRate;
        comboTimer = comboGap;
        lastHealth = health;
        TimeControl.timeHealth = health;

        for (int i = 0; i < health; i++)
        {
            heartList[i].gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.gameObject == target)
        {
            combo++;
            comboTimer = comboGap;
            score = score + 10 * combo;
            tutorialControl.spawn_menu_3();
            target.GetComponentInParent<TutorialEnemy>().SetAlive(false);
            audioSfx_success.PlayOneShot(monster_success, 0.8f);
            particle_system.Play();
            clawOverlay.animateBackward(0.25f);
            SetTarget(null);
        }
    }

    private void Update()
    {
        if(TimeControl.timeHealth > 0)
        {
            CheckHealth();
            CheckCombo();
            CheckGaze();
            Drift();
        }
    }

    public void CheckHealth()
    {
        if(health < lastHealth)
        {
            audioSfx_explode.PlayOneShot(monster_explode, 0.4f);
            heartList[health].gameObject.SetActive(false);
            redOverlayTop.startAnimate();
            redOverlayBot.startAnimate();
            TimeControl.timeHealth = health;
            lastHealth = health;
        }
    }

    public void CheckCombo()
    {
        if (comboTimer < 0)
        {
            combo = 0;
        }
        else
        {
            comboTimer -= Time.deltaTime;
        }
    }

    public void CheckGaze()
    {
        if (gazed != null && gazed.activeInHierarchy)
        {
            if (attackTimer < 0)
            {
                speed = (Vector3.Distance(gazed.transform.position, transform.position)) / 20;
                if (speed < 0.25f)
                {
                    clawOverlay.animateForward(1 / speed);
                }
                else
                {
                    clawOverlay.animateForward(speed);
                }
                audioSfx_dash.PlayOneShot(player_dash, 0.1f);
                SetTarget(gazed);
                SetGazed(null);
                attackTimer = attackRate - combo * 0.1f;
                if (attackTimer <= 1) attackTimer = 1;
                fillDuration = attackTimer;
            }
            else
            {
                attackTimer -= Time.deltaTime;
                TimeControl.timeMultiplier = 0.2f;
                reticle_mask.fillAmount += Time.deltaTime/ fillDuration;
                audioBgm.pitch = 0.5f;
                audioAmbient.volume = 0.05f;
            }
        }
        else
        {
            gazed = null;
            attackTimer = attackRate - combo * 0.1f;
            if (attackTimer <= 1) attackTimer = 1;
            fillDuration = attackTimer;
            TimeControl.timeMultiplier = 1f;
            reticle_mask.fillAmount = 0;
            audioBgm.pitch = 1f;
            audioAmbient.volume = 0.1f;
        }
    }

    public void Drift()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }

    public void SetTarget(GameObject gameObject)
    {
        target = gameObject;
    }

    public void SetGazed(GameObject gameObject)
    {
        gazed = gameObject;
    }
}
