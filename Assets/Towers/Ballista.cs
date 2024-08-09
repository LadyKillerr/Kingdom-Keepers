using System;
using System.Collections;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    [Header("Tower Audio")]
    [SerializeField] AudioClip placedAudio;
    [SerializeField][Range(0, 1)] float placedVolume;
    [SerializeField] AudioClip firingAudio;
    [SerializeField][Range(0, 1)] float firingVolume;

    [SerializeField] GameObject ballistaTop;

    int previousNumberOfParticles;
    int currentNumberOfParticles;
    [SerializeField] ParticleSystem boltParticles;

    [SerializeField] int ballistaCost = 75;
    public int TowerCost { get { return ballistaCost; } }

    GameObject parentGameObject;


    // reference
    AudioSource towerAudio;


    void Awake()
    {
        towerAudio = GetComponent<AudioSource>();

    }

    void Start()
    {

        previousNumberOfParticles = 0;

        if (towerAudio != null)
        {
            PlayPlacedAudio();
        }
    }

    void Update()
    {


        if (towerAudio != null) { PlayBoltFiringSFX(); }

    }

    public void PlaceTowers(GameObject towerToBePlaced, Vector3 positionToBePlaced)
    {
        Bank bank = FindAnyObjectByType<Bank>();
        parentGameObject = GameObject.FindWithTag("TowerPool");

        if (bank.CurrentBalance >= ballistaCost)
        {

            bank.Withdrawal(ballistaCost);

            // spawn towers
            GameObject placedTower = Instantiate(towerToBePlaced, positionToBePlaced, Quaternion.identity);

            // rearrange them to clean up the hierarchy
            placedTower.transform.parent = parentGameObject.transform;

        }

    }

    #region TowerAudio
    void PlayBoltFiringSFX()
    {
        currentNumberOfParticles = boltParticles.particleCount;

        // chạy âm thanh nếu số Particles được spawn ra nhiều hơn số Particles được lưu trong biến
        if (currentNumberOfParticles > previousNumberOfParticles)
        {
            PlayFiringAudio();
        }

        // gán 2 số bằng nhau
        previousNumberOfParticles = currentNumberOfParticles;
    }


    void PlayAudioClip(AudioClip audioToPlay, float volume)
    {
        towerAudio.PlayOneShot(audioToPlay, volume);
    }

    public void PlayFiringAudio()
    {
        PlayAudioClip(firingAudio, firingVolume);
    }

    public void PlayPlacedAudio()
    {
        PlayAudioClip(placedAudio, placedVolume);
    }
    #endregion


}
