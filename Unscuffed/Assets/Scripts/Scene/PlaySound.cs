using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _baseGameSound;
    [SerializeField] private AudioClip _playIntro;

    public void Play(AudioClip toPlay)
    {
        _baseGameSound.clip = toPlay;
        _baseGameSound.Play();
    }

    public void PlayMusic(AudioClip music)
    {
        _musicSource.clip = music;
        _musicSource.Play();
    }

    public void PlayIntro()
    {
        _baseGameSound.clip = _playIntro;
        _baseGameSound.Play();
    }
}