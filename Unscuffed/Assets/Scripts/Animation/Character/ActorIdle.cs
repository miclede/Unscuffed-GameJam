using UnityEngine;

[CreateAssetMenu(fileName = "Actor_Idle", menuName = "Actor/Idle")]
public class ActorIdle : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        base.getAnimation(actor);
        
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool idleTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_Idle);

        if ((Rotation > 270 || Rotation < 90))
            SetAnimator(VarCharacterAnim.D_Idle, true);
        else SetAnimator(VarCharacterAnim.D_Idle, false);

        if ((Rotation < 270 && Rotation > 90))
            SetAnimator(VarCharacterAnim.A_Idle, true);
        else SetAnimator(VarCharacterAnim.A_Idle, false);

        if (idleTag)
            SetAnimator(VarCharacterAnim.Idle, true);
        if (!idleTag)
            SetAnimator(VarCharacterAnim.Idle, false);

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