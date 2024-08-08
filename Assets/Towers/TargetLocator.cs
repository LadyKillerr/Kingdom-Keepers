using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform gun;
    [SerializeField] ParticleSystem boltParticles;
    [SerializeField] float range = 15;
    Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        FindClosetTarget();
        AimWeapon();
    }

    void FindClosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Transform closetEnemy = null;

        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closetEnemy = enemy.transform;
                maxDistance = targetDistance;
            }

            target = closetEnemy;
        }
    }


    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        gun.LookAt(target);

        if (targetDistance < range) 
        {
            Attack(true);
        }
        else 
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = boltParticles.emission;
        emissionModule.enabled = isActive;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}
