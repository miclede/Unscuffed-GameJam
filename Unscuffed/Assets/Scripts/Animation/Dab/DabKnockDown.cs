using UnityEngine;

[CreateAssetMenu(fileName = "Dab_KnockDown", menuName = "Dab/KnockDown")]
public class DabKnockDown : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool knockDownTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_KnockDown);

        if (actor.isDefeated)
        {
            if ((Rotation > 270 || Rotation < 90))
            {
                SetAnimator(VarDabAnim.D_KnockDown, true);
            }

            if ((Rotation < 270 && Rotation > 90))
            {
                SetAnimator(VarDabAnim.A_KnockDown, true);
            }
        }

        if (actor.isKnockDown)
        {
            if ((Rotation > 270 || Rotation < 90))
            {
                actor.canBeHurt = false;
                SetAnimator(VarDabAnim.D_KnockDown, true);
                actor.isKnockDown = false;
            }
            else SetAnimator(VarDabAnim.D_KnockDown, false);

            if ((Rotation < 270 && Rotation > 90))
            {
                actor.canBeHurt = false;
                SetAnimator(VarDabAnim.A_KnockDown, true);
                actor.isKnockDown = false;
            }
            else SetAnimator(VarDabAnim.A_KnockDown, false);
        }
        else
        {
            SetAnimator(VarDabAnim.D_KnockDown, false);
            SetAnimator(VarDabAnim.A_KnockDown, false);
        }

        if (knockDownTag)
            actor.canBeHurt = false;
            SetAnimator(VarDabAnim.KnockDown, true);
        if (!knockDownTag)
            SetAnimator(VarDabAnim.KnockDown, false);

        void SetAnimator(string name, bool value)
        {
            animator.SetBool(name, value);
        }
    }

    DabController GetController(Actor actor)
    {
        return actor.GetComponentInParent<DabController>();
    }
}
