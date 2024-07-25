using System.Collections;
using UnityEngine;

public class TowersControl : MonoBehaviour
{
    [SerializeField] AudioClip placedAudio;
    [SerializeField][Range(0, 1)] float placedVolume;
    [SerializeField] AudioClip firingAudio;
    [SerializeField][Range(0, 1)] float firingVolume;


    [SerializeField] GameObject ballistaTop;

    [SerializeField] bool isFiring = false;
    EnemyMover enemy;

    AudioSource towerAudio;
    [SerializeField] ParticleSystem boltParticles;

    void Awake()
    {
        towerAudio = GetComponent<AudioSource>();
        enemy = FindAnyObjectByType<EnemyMover>();
    }

    void Start()
    {
        if (towerAudio != null)
        {
            towerAudio.PlayOneShot(placedAudio, placedVolume);
        }


    }

    void Update()
    {
        //GameObject enemy = GameObject.FindWithTag("Enemy");
        ballistaTop.transform.LookAt(enemy.transform);


        //StartCoroutine(PlayFiringAudio());
    }

    IEnumerator PlayFiringAudio()
    {
        if (boltParticles.isPlaying && isFiring == false)
        {
            towerAudio.PlayOneShot(firingAudio, firingVolume);

            isFiring = true;
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(firingAudio.length);

            isFiring = false;
        }
        
    }
}
