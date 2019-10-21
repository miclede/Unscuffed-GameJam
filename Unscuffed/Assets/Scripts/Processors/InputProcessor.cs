using UnityEngine;

[CreateAssetMenu(fileName = "Input", menuName = "Processor/Input")]
public class InputProcessor : ScriptableObject
{
    public Vector2 getDabMoveInput()
    {
        float HorizontalInput = Input.GetAxis(VarInput.Horizontal);
        float VerticalInput = Input.GetAxis(VarInput.Vertical);

        if ((HorizontalInput != 0) || (VerticalInput != 0))
        {
            return new Vector2(HorizontalInput, VerticalInput);
        }
        return new Vector2(0, 0);
    }

    public Vector3 LookRotationDab(Actor actor)
    {
        return actor.GetComponentInChildren<DabLookAt>().LookAtRotation;
    }

    public Vector3 LookRotationActor(Actor actor)
    {
        return actor.GetComponentInChildren<ActorLookAt>().LookAtRotation;
    }

    public Vector2 getDabPosititon(DabController dab)
    {
        return new Vector2 (dab.transform.position.x, 0.1f);
    }
}