using UnityEngine;

[CreateAssetMenu(fileName = "Dab_Toss", menuName = "Dab/Toss")]
public class Dab_Toss : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        DabController Dab = GetController(actor);
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool Attack = animator.GetBool(VarDabAnim.Attack);
        bool TossTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_Toss);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (Dab.CooldownTimer())
        {
            actor.canBeHurt = false;
            if ((Rotation > 270 || Rotation < 90))
                SetAnimator(VarDabAnim.D_Toss, true);

            if (Rotation < 270 && Rotation > 90)
                SetAnimator(VarDabAnim.A_Toss, true);
        }
        else
        {
            SetAnimator(VarDabAnim.D_Toss, false);
            SetAnimator(VarDabAnim.A_Toss, false);
        }
        
        if (TossTag && cliptime < .9f)
        {
            SetAnimator(VarDabAnim.Toss, true);
            SetAnimator(VarDabAnim.Attack, true);
        }
        if (TossTag && cliptime > .85f)
        {
            actor.canBeHurt = true;
            SetAnimator(VarDabAnim.Attack, false);
        }
            
        if (!TossTag || (TossTag && cliptime > .9f))
        {
            SetAnimator(VarDabAnim.Toss, false);
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
