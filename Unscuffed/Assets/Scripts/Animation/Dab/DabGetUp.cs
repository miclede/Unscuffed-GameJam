using UnityEngine;

[CreateAssetMenu(fileName = "Dab_GetUp", menuName = "Dab/GetUp")]
public class DabGetUp : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool knockDownTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_KnockDown);
        bool GetUpTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_GetUp);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (knockDownTag && !actor.isDefeated)
        {
            if ((Rotation > 270 || Rotation < 90) && cliptime > 0.9f)
            {
                SetAnimator(VarDabAnim.D_GetUp, true);
            }
            else SetAnimator(VarDabAnim.D_GetUp, false);

            if ((Rotation < 270 && Rotation > 90) && cliptime > 0.9f)
            {
                SetAnimator(VarDabAnim.A_GetUp, true);
            }
            else SetAnimator(VarDabAnim.A_GetUp, false);
        }
        else
        {
            SetAnimator(VarDabAnim.D_GetUp, false);
            SetAnimator(VarDabAnim.A_GetUp, false);
        }

        if (GetUpTag)
        {
            actor.canBeHurt = true;
            SetAnimator(VarDabAnim.Attack, false);
            SetAnimator(VarDabAnim.GetUp, true);
        }
        if (GetUpTag && cliptime > 0.9f)
            actor.canBeHurt = true;
        if (!GetUpTag || (GetUpTag && cliptime > 0.9f))
            SetAnimator(VarDabAnim.GetUp, false);

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
