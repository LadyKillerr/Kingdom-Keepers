using UnityEngine;

public class Waypoint : MonoBehaviour
{
    GameObject parent;
    [SerializeField] GameObject towersPrefab;

    [SerializeField] bool isPlaceable;
    // a property - a nicer and cleaner way of get method
    public bool IsPlaceable { get { return isPlaceable; } }

    private void Awake()
    {
        parent = GameObject.FindGameObjectWithTag("TowerPool");
    }

    void OnMouseDown()
    {
        if (isPlaceable)
        {

            Vector3 position = transform.position;

            GameObject placedTowers =  Instantiate(towersPrefab, position, Quaternion.identity);
            isPlaceable = false;

            placedTowers.transform.parent = parent.transform;
        }
    }
}
