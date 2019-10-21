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

    public void PlayAnimation()
    {
        AnimationProcessor.GetAnimation(this);
    }
}
