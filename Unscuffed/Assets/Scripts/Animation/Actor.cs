using UnityEngine;

public class Actor : MonoBehaviour
{
    public Animator Animator;

    public AnimationProcessor AnimationProcessor;
    [HideInInspector]
    public bool isDefeated;
    [HideInInspector]
    public bool isHurt;
    [HideInInspector]
    public bool isKnockDown;
    [HideInInspector]
    public bool canBeHurt;

    private PlaySound _playSound;

    private void Awake()
    {
        _playSound = FindFirstObjectByType<PlaySound>();
    }

    public void PlayAudio(AudioClip soundEffect)
    {
        _playSound.Play(soundEffect);
    }

    public void PlayAnimation()
    {
        AnimationProcessor.GetAnimation(this);
    }
}
