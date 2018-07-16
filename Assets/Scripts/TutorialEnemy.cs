using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public TutorialControl tutorialControl;
    public bool isAttack;
    public bool isMove;
    public ParticleSystem particle_system;
    public string monsterType;
    public SkinnedMeshRenderer skinMeshRenderer;
    public Material attackMaterial;
    public Material baseMaterial;
    public Renderer groundPlane;
    public TutorialPlayer tutorialPlayer;
    public float attackRate;
    public float growthSpeed;
    public float enemySpeed;
    public Vector3 enemyScale;

    private float attackTimer;
    private float moveTimer;
    private Vector3 target;

    private void Update()
    {
        if (isMove) Move();
        if (isAttack) Attack();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, enemySpeed * TimeControl.timeMultiplier);

        if (transform.position == target)
        {
            Vector3 finalPosition;
            finalPosition.x = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 2, groundPlane.bounds.size.x / 2);
            finalPosition.z = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 2, groundPlane.bounds.size.x / 2);
            finalPosition.y = UnityEngine.Random.Range(4f, 10f);
            target = finalPosition;
            transform.LookAt(target);
        }
    }


    private void Attack()
    {
        if (attackTimer < 0)
        {
            if (transform.localScale.x < 200 && transform.localScale.y < 200 && transform.localScale.z < 200)
            {
                skinMeshRenderer.material = attackMaterial;
                Vector3 temp = transform.localScale;
                temp.x += Time.deltaTime * growthSpeed * TimeControl.timeMultiplier;
                temp.y += Time.deltaTime * growthSpeed * TimeControl.timeMultiplier;
                temp.z += Time.deltaTime * growthSpeed * TimeControl.timeMultiplier;
                transform.localScale = temp;
            }
            else
            {
                tutorialPlayer.health -= 1;
                tutorialControl.spawn_menu_1();
                GameObject temp = Instantiate(particle_system.gameObject, transform.position + transform.up * 2f, Quaternion.identity);
                temp.SetActive(true);
                SetAlive(false);
            }
        }
        else
        {
            attackTimer -= Time.deltaTime * TimeControl.timeMultiplier;
        }
    }

    public bool GetAlive()
    {
        return gameObject.activeInHierarchy;
    }

    public void SetAlive(bool isBool)
    {
        gameObject.SetActive(isBool);

        if (isBool)
        {
            attackTimer = attackRate;
            transform.localScale = enemyScale;
            skinMeshRenderer.material = baseMaterial;

            Vector3 finalPosition;

            finalPosition.x = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 2, groundPlane.bounds.size.x / 2);
            finalPosition.z = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 2, groundPlane.bounds.size.x / 2);
            finalPosition.y = UnityEngine.Random.Range(4f, 10f);
            transform.localPosition = finalPosition;

            finalPosition.x = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 2, groundPlane.bounds.size.x / 2);
            finalPosition.z = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 2, groundPlane.bounds.size.x / 2);
            finalPosition.y = UnityEngine.Random.Range(4f, 10f);
            target = finalPosition;
            transform.LookAt(target);
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (gazedAt)
        {
            tutorialPlayer.SetGazed(gameObject);
        }
        else
        {
            tutorialPlayer.SetGazed(null);
        }
    }
}
