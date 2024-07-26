using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Transform towersBin;
    [SerializeField] GameObject towersPrefab;

    [SerializeField] bool isPlaceable;
    // a property - a nicer and cleaner way of get method
    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown()
    {
        if (isPlaceable)
        {

            Vector3 position = transform.position;

            GameObject placedTowers =  Instantiate(towersPrefab, position, Quaternion.identity);
            isPlaceable = false;

            placedTowers.transform.parent = towersBin.transform;
        }
    }
}
