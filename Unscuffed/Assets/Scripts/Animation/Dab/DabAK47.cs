using UnityEngine;

[CreateAssetMenu(fileName = "Dab_AK47", menuName = "Dab/AK47")]
public class DabAK47 : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        DabController Dab = GetController(actor);
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool Attack = animator.GetBool(VarDabAnim.Attack);
        bool AK47Tag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_AK47);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (Dab.Cache.AK47)
        {
            if ((Rotation > 270 || Rotation < 90))
                SetAnimator(VarDabAnim.D_AK47, true);

            if (Rotation < 270 && Rotation > 90)
                SetAnimator(VarDabAnim.A_AK47, true);
        }
        else
        {
            SetAnimator(VarDabAnim.D_AK47, false);
            SetAnimator(VarDabAnim.A_AK47, false);
        }

        if (AK47Tag && cliptime < .9f)
        {
            SetAnimator(VarDabAnim.AK47, true);
            SetAnimator(VarDabAnim.Attack, true);
        }
        if (AK47Tag && cliptime > .8f)
            SetAnimator(VarDabAnim.Attack, false);
        if (!AK47Tag || (AK47Tag && cliptime > .9f))
        {
            SetAnimator(VarDabAnim.AK47, false);
        }
            

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
