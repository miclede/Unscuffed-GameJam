using UnityEngine;

[CreateAssetMenu(fileName = "Actor_Toss", menuName = "Actor/Toss")]
public class ActorToss : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        ActorController Character = GetController(actor);
        float Rotation = Character.Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool TossTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_Toss);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (Character.AIProcessor.Toss && Character.CooldownTimer())
        {
            actor.canBeHurt = false;
            if ((Rotation > 270 || Rotation < 90))
                SetAnimator(VarCharacterAnim.D_Toss, true);

            if (Rotation < 270 && Rotation > 90)
                SetAnimator(VarCharacterAnim.A_Toss, true);
        }
        else
        {
            actor.canBeHurt = true;
            SetAnimator(VarCharacterAnim.D_Toss, false);
            SetAnimator(VarCharacterAnim.A_Toss, false);
        }

        if (TossTag && cliptime < .9f)
        {
            SetAnimator(VarCharacterAnim.Toss, true);
            SetAnimator(VarCharacterAnim.Attack, true);
        }

        if (TossTag && cliptime > .85f)
        {
            actor.canBeHurt = true;
            SetAnimator(VarCharacterAnim.Attack, false);
        }

        if (!TossTag || (TossTag && cliptime > .9f))
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
