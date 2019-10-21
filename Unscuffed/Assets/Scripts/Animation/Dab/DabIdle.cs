using UnityEngine;

[CreateAssetMenu(fileName = "Dab_Idle", menuName = "Dab/Idle")]
public class DabIdle : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        Vector2 MoveInput = GetController(actor).Cache.MoveInputVector;
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool hasTarget = GetController(actor).Cache.hasTarget;
        bool idleTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_Idle);

        if (hasTarget == true)
        {
            if ((Rotation > 270 || Rotation < 90))
                SetAnimator(VarDabAnim.D_Idle, true);
            else SetAnimator(VarDabAnim.D_Idle, false);

            if ((Rotation < 270 && Rotation > 90))
                SetAnimator(VarDabAnim.A_Idle, true);
            else SetAnimator(VarDabAnim.A_Idle, false);
        }

        if (hasTarget == false)
        {
            if (MoveInput.x > 0 && MoveInput.x < 0.2)
                SetAnimator(VarDabAnim.D_Idle, true);
            else SetAnimator(VarDabAnim.D_Idle, false);

            if (MoveInput.x > -0.2 && MoveInput.x < 0)
                SetAnimator(VarDabAnim.A_Idle, true);
            else SetAnimator(VarDabAnim.A_Idle, false);
        }

        if (idleTag)
        {
            actor.canBeHurt = true;
            SetAnimator(VarDabAnim.Idle, true);
        }
        if (!idleTag)
            SetAnimator(VarDabAnim.Idle, false);

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