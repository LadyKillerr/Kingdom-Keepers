using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    // a property - a nicer and cleaner way of get method

    private void Awake()
    {

    }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            if (towerPrefab != null)
            {
                // truyền vào script TowersControl prefab của tower và vị trí để towersControl Instantiate ra
                towerPrefab.GetComponent<Ballista>().PlaceTowers(towerPrefab, transform.position);

                // only change tiles placeable status if a towers is placed 
                isPlaceable = !isPlaceable;
            }
            else
            {
                Debug.Log("towerPrefab is null");
            }
        }

    }
}
