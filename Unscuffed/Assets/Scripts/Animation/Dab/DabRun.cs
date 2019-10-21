using UnityEngine;

[CreateAssetMenu(fileName = "Dab_Run", menuName = "Dab/Run")]
public class DabRun : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        Vector2 MoveInput = GetController(actor).Cache.MoveInputVector;
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool startRunTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_StartRun);
        bool runTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_Run);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (MoveInput.x > 0.2)
            SetAnimator(VarDabAnim.D_StartRun, true);
        else SetAnimator(VarDabAnim.D_StartRun, false);

        if (MoveInput.x < -0.2)
            SetAnimator(VarDabAnim.A_StartRun, true);
        else SetAnimator(VarDabAnim.A_StartRun, false);

        if (MoveInput.x > 0.8)
            SetAnimator(VarDabAnim.D_Run, true);
        if (MoveInput.x < 0.2)
            SetAnimator(VarDabAnim.D_Run, false);

        if (MoveInput.x < -0.8)
            SetAnimator(VarDabAnim.A_Run, true);
        if (MoveInput.x > -0.2)
            SetAnimator(VarDabAnim.A_Run, false);


        if (startRunTag)
            SetAnimator(VarDabAnim.StartRun, true);
        if (!startRunTag)
            SetAnimator(VarDabAnim.StartRun, false);

        if (runTag)
            SetAnimator(VarDabAnim.Run, true);
        if (!runTag)
            SetAnimator(VarDabAnim.Run, false);



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
