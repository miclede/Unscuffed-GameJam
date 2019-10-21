using UnityEngine;

[CreateAssetMenu(fileName = "MP", menuName = "Processor/Movement")]
public class MovementProcessor : ScriptableObject
{
    private Rigidbody2D body;
    public Rigidbody2D Body
    {
        get { return body; }
        set
        {
            if (!body)
            {
                body = value;
            }
            else if (body != value)
            {
                body = value;
            }
        }
    }

    void getBodyDab(DabController dab)
    {
        Body = dab.GetComponent<Rigidbody2D>();
    }

    public void MoveDab(DabController Dab, Vector2 Movement, float Speed)
    {
        if (!Dab.actor.Animator.GetBool(VarDabAnim.Attack) && !Dab.actor.isHurt && !Dab.actor.isKnockDown && Dab.actor.canBeHurt)
        {
            getBodyDab(Dab);
            Body.velocity = new Vector2(Movement.x, 0) * Speed;
        }
        else if (!Dab.actor.isKnockDown)
            Body.velocity = new Vector2(0, 0);

        if (Dab.actor.Animator.GetBool(VarDabAnim.KnockDown))
        {
            if (Dab.Cache.Rotation.z > 270 || Dab.Cache.Rotation.z < 90)
            {
                Body.velocity = new Vector2(-1, 0) * Speed * 1.19f;
            }

            if (Dab.Cache.Rotation.z < 270 && Dab.Cache.Rotation.z > 90)
            {
                Body.velocity = new Vector2(1, 0) * Speed * 1.19f;
            }
        }

    }

    public void MoveActor(Vector2 dabposition, ActorController character, float speed)
    {
        if (!character.stopMove && !character.actor.Animator.GetBool(VarCharacterAnim.KnockDown) && 
            !character.actor.isHurt && character.actor.canBeHurt && !character.AIProcessor.FireRifle && !character.AIProcessor.SpecialAttack && !character.AIProcessor.Toss)
            character.transform.position = Vector2.MoveTowards(character.transform.position, dabposition, speed * Time.deltaTime);
    }

}
