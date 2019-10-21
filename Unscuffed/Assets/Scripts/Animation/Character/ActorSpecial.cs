using UnityEngine;

[CreateAssetMenu(fileName = "Actor_Special", menuName = "Actor/Special")]
public class ActorSpecial : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        ActorController Character = GetController(actor);
        float Rotation = Character.Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool SpecialTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_Special);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (Character.AIProcessor.SpecialAttack && Character.CooldownTimer())
        {
            actor.canBeHurt = false;
            if ((Rotation > 270 || Rotation < 90))
                SetAnimator(VarCharacterAnim.D_Special, true);

            if (Rotation < 270 && Rotation > 90)
                SetAnimator(VarCharacterAnim.A_Special, true);
        }
        else
        {
            actor.canBeHurt = true;
            SetAnimator(VarCharacterAnim.D_Special, false);
            SetAnimator(VarCharacterAnim.A_Special, false);
        }

        if (SpecialTag && cliptime < .9f)
        {
            SetAnimator(VarCharacterAnim.Special, true);
            SetAnimator(VarCharacterAnim.Attack, true);
        }

        if (SpecialTag && cliptime > .85f)
        {
            actor.canBeHurt = true;
            SetAnimator(VarCharacterAnim.Attack, false);
        }
            
        if (!SpecialTag || (SpecialTag && cliptime > .9f))
        {
            SetAnimator(VarCharacterAnim.Special, false);
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
