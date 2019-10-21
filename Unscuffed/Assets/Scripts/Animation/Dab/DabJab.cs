using UnityEngine;

[CreateAssetMenu(fileName = "Dab_Jab", menuName = "Dab/Jab")]
public class DabJab : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        DabController Dab = GetController(actor);
        float Rotation = Dab.Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool Attack = animator.GetBool(VarDabAnim.Attack);
        bool hasTarget = GetController(actor).Cache.hasTarget;
        bool jabTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarDabAnim.Tag_Jab);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (hasTarget == true)
        {
            if (Dab.Cache.LeftClick && !Attack)
            {
                if ((Rotation > 270 || Rotation < 90))
                    SetAnimator(VarDabAnim.D_Jab, true);

                if (Rotation < 270 && Rotation > 90)
                    SetAnimator(VarDabAnim.A_Jab, true);
            }

            else if (Dab.Cache.LeftClick && Attack)
            {
                if ((Rotation > 270 || Rotation < 90))
                {
                    if (cliptime > 0.55f)
                        SetAnimator(VarDabAnim.D_Jab, true);
                }

                if ((Rotation < 270 && Rotation > 90))
                {
                    if (cliptime > 0.55f)
                        SetAnimator(VarDabAnim.A_Jab, true);
                }
            }
            else
            {
                SetAnimator(VarDabAnim.D_Jab, false);
                SetAnimator(VarDabAnim.A_Jab, false);
            }

            if (jabTag && cliptime < .9f)
                SetAnimator(VarDabAnim.Attack, true);
            if (jabTag && cliptime >= .9f)
                SetAnimator(VarDabAnim.Attack, false);
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