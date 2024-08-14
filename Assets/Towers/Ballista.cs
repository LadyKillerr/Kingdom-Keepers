using System;
using System.Collections;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    
    [SerializeField] GameObject ballistaTop;

    int previousNumberOfParticles;
    int currentNumberOfParticles;
    [SerializeField] ParticleSystem boltParticles;

    [SerializeField] int ballistaCost = 75;
    public int BallistaCost { get { return ballistaCost; } }

    GameObject parentGameObject;


    // reference
    AudioSource towerAudio;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        towerAudio = GetComponent<AudioSource>();

    }

    void Start()
    {

        previousNumberOfParticles = 0;

        if (towerAudio != null)
        {
            audioManager.PlayPlacedAudio();
        }
    }

    void Update()
    {
        //if (towerAudio != null) { PlayBallistaFiringSFX(); }

    }

    public void PlaceTowers(GameObject towerToBePlaced, Vector3 positionToBePlaced)
    {
        Bank bank = FindAnyObjectByType<Bank>();
        parentGameObject = GameObject.FindWithTag("TowerPool");




        bank.Withdrawal(ballistaCost);

        // spawn towers
        GameObject placedTower = Instantiate(towerToBePlaced, positionToBePlaced, Quaternion.identity);

        // rearrange them to clean up the hierarchy
        placedTower.transform.parent = parentGameObject.transform;



    }


    void PlayBallistaFiringSFX()
    {
        currentNumberOfParticles = boltParticles.particleCount;

        // chạy âm thanh nếu số Particles được spawn ra nhiều hơn số Particles được lưu trong biến
        if (currentNumberOfParticles > previousNumberOfParticles)
        {
            audioManager.PlayFiringAudio();
        }

        // gán 2 số bằng nhau
        previousNumberOfParticles = currentNumberOfParticles;
    }






}
