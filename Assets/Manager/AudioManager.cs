using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Tower Audio")]
    [SerializeField] AudioClip placedAudio;
    [SerializeField][Range(0, 1)] float placedVolume;
    [SerializeField] AudioClip firingAudio;
    [SerializeField][Range(0, 1)] float firingVolume;
    [SerializeField] AudioClip lackGoldAudio;
    [SerializeField][Range(0, 1)] float lackGoldVolume;

    AudioSource audioManager;

    void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayAudioClip(AudioClip audioToPlay, float volume)
    {
        if (audioToPlay != null && volume > 0)
        {
            audioManager.PlayOneShot(audioToPlay, volume);
        }
    }

    public void PlayFiringAudio()
    {
        PlayAudioClip(firingAudio, firingVolume);
    }

    public void PlayPlacedAudio()
    {
        PlayAudioClip(placedAudio, placedVolume);
    }

    public void PlayLackGoldAudio()
    {
        PlayAudioClip(lackGoldAudio, lackGoldVolume);
    }
}
