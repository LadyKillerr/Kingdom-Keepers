using System;
using System.Collections;
using UnityEngine;

public class TowersControl : MonoBehaviour
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

    EnemyMover enemy;

    AudioSource towerAudio;

    void Awake()
    {
        towerAudio = GetComponent<AudioSource>();
        enemy = FindAnyObjectByType<EnemyMover>();


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
        // make towers look at enemy
        if (enemy != null)
        {
            ballistaTop.transform.LookAt(enemy.transform);

        }

        PlayBoltFiringSFX();

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
