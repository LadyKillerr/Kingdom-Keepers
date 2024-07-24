using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> enemyPath = new List<Waypoint>();
    [SerializeField] [InspectorRange(0f,5f)]float movementSpeed = 1f;

    private void Update()
    {
        
    }

    void Start()
    {
        StartCoroutine(ListWaypointCoordinates());


    }

    IEnumerator ListWaypointCoordinates()
    {
        foreach (Waypoint waypoint in enemyPath)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;

            transform.LookAt(endPosition);

            float travelPercent = 0f;

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * movementSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
