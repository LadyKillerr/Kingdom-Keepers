using System;
using System.Reflection.Emit;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class CoordinatesUpdater : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();


    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateTilesName();
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt((transform.position.x) / EditorSnapSettings.gridSize.x);
        coordinates.y = Mathf.RoundToInt((transform.position.z) / EditorSnapSettings.gridSize.z);

        label.text = coordinates.x + "," + coordinates.y;

    }

    void UpdateTilesName()
    {
        //transform.parent.name = coordinates.x + "," + coordinates.y;
        transform.parent.name = coordinates.ToString();
    }
}
