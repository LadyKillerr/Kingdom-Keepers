using System;
using System.Reflection.Emit;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinatesUpdater : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor  = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0); // orange



    private void Awake()
    {
        gridManager = FindAnyObjectByType<GridManager>();

        label = GetComponent<TextMeshPro>();

        DisplayCoordinates();

        // Coordinates is not showing by default - whenever needed press C
        label.enabled = true;

    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateTilesName();
        }
        ChangeCoordinatesColor();
        //ToggleCoordinates();
    }

    void ToggleCoordinates()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //if (isCoordinates)
            //{
            //    label.enabled = false;
            //    isCoordinates = false;
            //}
            //else
            //{
            //    label.enabled = true;
            //    isCoordinates = true;
            //}
            label.enabled = !label.IsActive();
        }
    }

    void ChangeCoordinatesColor()
    {
        if (gridManager == null){ return ; }

        Node node = gridManager.GetNode(coordinates);

        if (node == null){ return;  }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        } 
        else if (node.isWalkable)
        {
            label.color = pathColor;
        }
        else
        {
            label.color = defaultColor;
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
