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

    void Start()
    {
        // tìm đường
        FindPath();

        // đưa enemyback lại điểm đầu 
        ReturnToStart();

        // bắt đầu mò đường để đi 
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        enemyPath.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        //foreach(GameObject child in parent.transform)
        //{
        //    enemyPath.Add(child.GetComponent<Waypoint>());
        //}

        for(int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;

            enemyPath.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = enemyPath[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in enemyPath)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;

            transform.LookAt(endPosition);

            // tạo biến travelPercent dựa trên thời gian 
            float travelPercent = 0f;

            // sử dụng hàm VectorLerp để đưa vật tới đích đến 1 cách mượt mà thay vì + position trong Update
            while (travelPercent < 1f)
            {
                // tăng biến Travel Percent lên dần, 1s là sẽ tới endPosition
                travelPercent += Time.deltaTime * movementSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        Destroy(gameObject);

    }
}
