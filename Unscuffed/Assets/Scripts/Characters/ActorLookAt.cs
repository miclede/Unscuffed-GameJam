using UnityEngine;

public class ActorLookAt : MonoBehaviour
{
    [HideInInspector]
    public Vector3 LookAtRotation;

    public DabController DabController;

    private GameObject TargetFighter;

    void Rotate()
    {
        if (TargetFighter != DabController.gameObject)
            TargetFighter = DabController.gameObject;

        if (TargetFighter != null)
        {
            transform.right = TargetFighter.transform.position - transform.position;
            LookAtRotation = transform.rotation.eulerAngles;
        }
    }

    private void Update()
    {
        Rotate();
    }

}
