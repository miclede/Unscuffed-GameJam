using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    private PlaySound _playSound;

    [SerializeField] private AudioClip _musicToPlay;

    private void Awake()
    {
        _playSound = FindFirstObjectByType<PlaySound>();
    }

    private void Start()
    {
        _playSound.PlayMusic(_musicToPlay);
    }
}
