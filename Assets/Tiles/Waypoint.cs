using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Transform towersBin;
    [SerializeField] GameObject towersPrefab;

    [SerializeField] bool isPlaceable;

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
