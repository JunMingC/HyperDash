using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Rigidbody rigidBody;
    public ParticleSystem particle_system;
    public SkinnedMeshRenderer skinMeshRenderer;
    public Material attackMaterial;
    public Material baseMaterial;
    public Renderer groundPlane;
    public PlayerControl playerControl;
    public float attackRate;
    public float growthSpeed;
    public float enemySpeed;
    public Vector3 enemyScale;

    private float attackTimer;
    private float moveTimer;
    private Vector3 target;

    private void Update()
    {
        if (TimeControl.timeHealth > 0)
        {
            Move();
            Attack();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, enemySpeed * TimeControl.timeMultiplier);
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;

        if (transform.position == target)
        {
            Vector3 finalPosition;
            finalPosition.x = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 4, groundPlane.bounds.size.x / 4);
            finalPosition.z = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 4, groundPlane.bounds.size.x / 4);
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
                playerControl.health -= 1;
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

            finalPosition.x = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 4, groundPlane.bounds.size.x / 4);
            finalPosition.z = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 4, groundPlane.bounds.size.x / 4);
            finalPosition.y = UnityEngine.Random.Range(4f, 10f);
            transform.localPosition = finalPosition;

            finalPosition.x = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 4, groundPlane.bounds.size.x / 4);
            finalPosition.z = UnityEngine.Random.Range(-groundPlane.bounds.size.x / 4, groundPlane.bounds.size.x / 4);
            finalPosition.y = UnityEngine.Random.Range(4f, 10f);
            target = finalPosition;
            transform.LookAt(target);
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (gazedAt)
        {
            playerControl.SetGazed(gameObject);
        }
        else 
        {
            playerControl.SetGazed(null);
        }
    }

    public void StopExpand()
    {
        attackTimer = attackRate;
    }
}
