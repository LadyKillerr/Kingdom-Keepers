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

    Waypoint waypoint;

    [SerializeField] Color waypointColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;


    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();

        // Coordinates is not showing by default - whenever needed press C
        label.enabled = false;

    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateTilesName();
        }
        ChangeCoordinatesColor();
        ToggleCoordinates();
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
        if (waypoint.IsPlaceable)
        {
            label.color = waypointColor;
        }
        else if (!waypoint.IsPlaceable)
        {
            label.color = blockedColor;
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
