using UnityEngine;

[CreateAssetMenu(fileName = "Dab_Jump", menuName = "Dab/Jump")]
public class DabJump : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool jumpTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_Jump);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (GetController(actor).Cache.Space)
        {
            if (Rotation > 270 || Rotation < 90)
                SetAnimator(VarDabAnim.JumpD, true);

            if (Rotation < 270 && Rotation > 90)
                SetAnimator(VarDabAnim.JumpA, true);
        }
        else
        {
            SetAnimator(VarDabAnim.JumpD, false);
            SetAnimator(VarDabAnim.JumpA, false);
        }

        if (!jumpTag)
            SetAnimator(VarDabAnim.Jump, false);

        if (jumpTag)
            SetAnimator(VarDabAnim.Jump, true);

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
