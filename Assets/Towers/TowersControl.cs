using UnityEngine;

public class TowersControl : MonoBehaviour
{
    [SerializeField] AudioClip placedAudio;
    [SerializeField][Range(0, 1)] float volume;

    [SerializeField] GameObject ballistaTop;
    EnemyMover enemy;

    AudioSource towerAudio;


    void Awake()
    {
        towerAudio = GetComponent<AudioSource>();
        enemy = FindAnyObjectByType<EnemyMover>();
    }

    void Start()
    {
        towerAudio.PlayOneShot(placedAudio, volume);
    }

    void Update()
    {
        //GameObject enemy = GameObject.FindWithTag("Enemy");
        ballistaTop.transform.LookAt(enemy.transform);
    }



}
