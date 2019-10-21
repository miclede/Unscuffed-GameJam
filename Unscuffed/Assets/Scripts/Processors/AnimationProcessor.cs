using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AP_", menuName = "Processor/Animation")]
public class AnimationProcessor : ScriptableObject
{
    public List<AnimBase> Animations = new List<AnimBase>();

    public void GetAnimation(Actor actor)
    {
        foreach (AnimBase anim in Animations)
        {
            anim.getAnimation(actor);
        }
    }
}