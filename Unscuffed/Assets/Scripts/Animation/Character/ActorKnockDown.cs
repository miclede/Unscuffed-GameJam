using UnityEngine;

[CreateAssetMenu(fileName = "Actor_KnockDown", menuName = "Actor/KnockDown")]
public class ActorKnockDown : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool knockDownTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_KnockDown);

        if (actor.isDefeated)
        {
            if ((Rotation > 270 || Rotation < 90))
            {
                SetAnimator(VarCharacterAnim.D_KnockDown, true);
            }

            if ((Rotation < 270 && Rotation > 90))
            {
                SetAnimator(VarCharacterAnim.A_KnockDown, true);
            }
        }

        if (actor.isKnockDown)
        {
            if ((Rotation > 270 || Rotation < 90))
            {
                actor.canBeHurt = false;
                SetAnimator(VarCharacterAnim.D_KnockDown, true);
                actor.isKnockDown = false;
            }
            else SetAnimator(VarCharacterAnim.D_KnockDown, false);

            if ((Rotation < 270 && Rotation > 90))
            {
                actor.canBeHurt = false;
                SetAnimator(VarCharacterAnim.A_KnockDown, true);
                actor.isKnockDown = false;
            }
            else SetAnimator(VarCharacterAnim.A_KnockDown, false);
        }
        else
        {
            SetAnimator(VarCharacterAnim.D_KnockDown, false);
            SetAnimator(VarCharacterAnim.A_KnockDown, false);
        }

        if (knockDownTag)
            actor.canBeHurt = false;
            SetAnimator(VarCharacterAnim.KnockDown, true);
        if (!knockDownTag)
            SetAnimator(VarCharacterAnim.KnockDown, false);

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
