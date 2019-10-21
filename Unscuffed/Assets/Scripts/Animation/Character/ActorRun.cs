using UnityEngine;

[CreateAssetMenu(fileName = "Actor_Run", menuName = "Actor/Run")]
public class ActorRun : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        ActorController Character = GetController(actor);
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool runTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_Run);

        if (!Character.AllStop && !Character.stopMove)
        {
            if (Character.Cache.MoveVector.x > 0)
                SetAnimator(VarCharacterAnim.D_Run, true);
            else SetAnimator(VarCharacterAnim.D_Run, false);

            if (Character.Cache.MoveVector.x < 0)
                SetAnimator(VarCharacterAnim.A_Run, true);
            else SetAnimator(VarCharacterAnim.A_Run, false);
        }
        else
        {
            SetAnimator(VarCharacterAnim.D_Run, false);
            SetAnimator(VarCharacterAnim.A_Run, false);
        }

        if (runTag)
            SetAnimator(VarCharacterAnim.Run, true);
        if (!runTag)
            SetAnimator(VarCharacterAnim.Run, false);

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
