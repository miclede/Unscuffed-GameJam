using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip jabClip;
    public AudioClip buttonClip;
    public AudioClip upperCutClip;
    public AudioClip thurstClip;
    public AudioClip bulletClip;
    public AudioClip explosionClip;

    void Play()
    {
        sound.Play();
    }

    public void playJab()
    {
        sound.clip = jabClip;
        Play();
    }

    public void playThrust()
    {
        sound.clip = thurstClip;
        Play();
    }

    public void playUpperCut()
    {
        sound.clip = upperCutClip;
        Play();
    }

    public void playButton()
    {
        sound.clip = buttonClip;
        Play();
    }

    public void playExplosion()
    {
        sound.clip = explosionClip;
        Play();
    }

    public void playBullet()
    {
        sound.clip = bulletClip;
        Play();
    }

}