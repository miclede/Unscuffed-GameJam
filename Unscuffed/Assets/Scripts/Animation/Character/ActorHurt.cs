using UnityEngine;

[CreateAssetMenu(fileName = "Actor_Hurt", menuName = "Actor/Hurt")]
public class ActorHurt : AnimBase
{
    public override void getAnimation(Actor actor)
    {
        float Rotation = GetController(actor).Cache.Rotation.z;
        Animator animator = actor.Animator;
        bool hurtTag = animator.GetCurrentAnimatorStateInfo(0).IsTag(VarCharacterAnim.Tag_Hurt);
        float cliptime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (actor.isHurt)
        {
            if ((Rotation > 270 || Rotation < 90))
            {
                SetAnimator(VarCharacterAnim.D_Hurt, true);
                
            }
            else SetAnimator(VarCharacterAnim.D_Hurt, false);

            if ((Rotation < 270 && Rotation > 90))
            { 
                SetAnimator(VarCharacterAnim.A_Hurt, true);
            }
            else SetAnimator(VarCharacterAnim.A_Hurt, false);
        }
        else
        {
            SetAnimator(VarCharacterAnim.D_Hurt, false);
            SetAnimator(VarCharacterAnim.A_Hurt, false);
        }

        if (hurtTag)
        {
            SetAnimator(VarCharacterAnim.Attack, false);
            SetAnimator(VarCharacterAnim.Hurt, true);
        }

        if(hurtTag && cliptime > .85f)
        {
            actor.isHurt = false;
        }
            
        if (!hurtTag || (hurtTag && cliptime > .5f)) 
            SetAnimator(VarCharacterAnim.Hurt, false);
            

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
