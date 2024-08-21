using System.Collections;
using TMPro;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject ballistaPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    // a property - a nicer and cleaner way of get method

    [SerializeField] GameObject lackGoldWarning;
    [SerializeField] float lackGoldWarningAppearTime = 2f;

    Bank bank;
    AudioManager audioManager;
    SessionManager sessionManager;

    private void Awake()
    {
        bank = FindAnyObjectByType<Bank>();
        audioManager = FindAnyObjectByType<AudioManager>();
        sessionManager = FindAnyObjectByType<SessionManager>();
        lackGoldWarning = GameObject.FindGameObjectWithTag("LackGoldWarning");
    }

    void OnMouseDown()
    {
        if (isPlaceable && !sessionManager.IsPaused)
        {
            if (ballistaPrefab != null && bank.CurrentBalance >= ballistaPrefab.GetComponent<Ballista>().BallistaCost )
            {
                // truyền vào script TowersControl prefab của tower và vị trí để towersControl Instantiate ra
                ballistaPrefab.GetComponent<Ballista>().PlaceTowers(ballistaPrefab, transform.position);

                // only change tiles placeable status if a towers is placed 
                isPlaceable = !isPlaceable;

                
            }
            else
            {
                // Play lack of gold warning and SFX
                audioManager.PlayLackGoldAudio();

                if (lackGoldWarning != null){ lackGoldWarning.GetComponent<TextMeshProUGUI>().enabled = true; }

                StartCoroutine(ResetLackGoldWarning(lackGoldWarningAppearTime));

                Debug.Log("You Dont Have Enough Gold To Build A Ballista"); 
            }
        }

    }

    IEnumerator ResetLackGoldWarning(float warningAppearTime)
    {
        yield return new WaitForSeconds(warningAppearTime);

        if (lackGoldWarning != null){ lackGoldWarning.GetComponent<TextMeshProUGUI>().enabled = false; }
        
    }
}
