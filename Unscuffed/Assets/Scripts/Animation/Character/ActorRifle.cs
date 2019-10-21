using UnityEngine;

[CreateAssetMenu(fileName = "Actor_Rifle", menuName = "Actor/Rifle")]
public class ActorRifle : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        ActorController Character = GetController(actor);
        float Rotation = Character.Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool RifleTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_Rifle);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (Character.AIProcessor.FireRifle)
        {
            if ((Rotation > 270 || Rotation < 90))
                SetAnimator(VarCharacterAnim.D_Rifle, true);

            if (Rotation < 270 && Rotation > 90)
                SetAnimator(VarCharacterAnim.A_Rifle, true);
        }
        else
        {
            SetAnimator(VarCharacterAnim.D_Rifle, false);
            SetAnimator(VarCharacterAnim.A_Rifle, false);
        }

        if (RifleTag && cliptime < .9f)
        {
            SetAnimator(VarCharacterAnim.Rifle, true);
            SetAnimator(VarCharacterAnim.Attack, true);
        }
        if (!RifleTag || (RifleTag && cliptime > .9f))
        {
            SetAnimator(VarCharacterAnim.Rifle, false);
            SetAnimator(VarCharacterAnim.Attack, false);
        }

        void SetAnimator(string name, bool value)
        {
            animator.SetBool(name, value);
        }
    }

    ActorController GetController(Actor actor)
    {
        return actor.GetComponentInParent<ActorController>();
    }
}
