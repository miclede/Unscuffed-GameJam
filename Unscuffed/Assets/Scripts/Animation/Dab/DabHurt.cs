using UnityEngine;

[CreateAssetMenu(fileName = "Dab_Hurt", menuName = "Dab/Hurt")]
public class DabHurt : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool hurtTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_Hurt);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (actor.isHurt)
        {
            if ((Rotation > 270 || Rotation < 90))
            {
                SetAnimator(VarDabAnim.D_Hurt, true);
                actor.isHurt = false;
            }
            else SetAnimator(VarDabAnim.D_Hurt, false);

            if ((Rotation < 270 && Rotation > 90))
            {
                SetAnimator(VarDabAnim.A_Hurt, true);
                actor.isHurt = false;
            } 
            else SetAnimator(VarDabAnim.A_Hurt, false);
        }
        else
        {
            SetAnimator(VarDabAnim.D_Hurt, false);
            SetAnimator(VarDabAnim.A_Hurt, false);
        }

        if (hurtTag)
        {
            SetAnimator(VarDabAnim.Hurt, true);
            SetAnimator(VarDabAnim.Attack, false);
        }  
        if (!hurtTag || (hurtTag && cliptime > .9f))
            SetAnimator(VarDabAnim.Hurt, false);

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