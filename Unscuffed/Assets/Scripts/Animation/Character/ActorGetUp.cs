using UnityEngine;

[CreateAssetMenu(fileName = "Actor_GetUp", menuName = "Actor/GetUp")]
public class ActorGetUp : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool knockDownTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_KnockDown);
        bool GetUpTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_GetUp);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (knockDownTag && !actor.isDefeated)
        {
            if ((Rotation > 270 || Rotation < 90) && cliptime > 0.9f)
            {
                SetAnimator(VarCharacterAnim.D_GetUp, true);
            }
            else SetAnimator(VarCharacterAnim.D_GetUp, false);

            if ((Rotation < 270 && Rotation > 90) && cliptime > 0.9f)
            {
                SetAnimator(VarCharacterAnim.A_GetUp, true);
            }
            else SetAnimator(VarCharacterAnim.A_GetUp, false);
        }
        else
        {
            SetAnimator(VarCharacterAnim.D_GetUp, false);
            SetAnimator(VarCharacterAnim.A_GetUp, false);
        }

        if (GetUpTag)
        {
            SetAnimator(VarCharacterAnim.GetUp, true);
            SetAnimator(VarCharacterAnim.Attack, false);
        }
            SetAnimator(VarCharacterAnim.GetUp, true);
        if (GetUpTag && cliptime > 0.9f)
            actor.canBeHurt = true;
        if (!GetUpTag || (GetUpTag && cliptime > 0.9f))
            SetAnimator(VarCharacterAnim.GetUp, false);

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
