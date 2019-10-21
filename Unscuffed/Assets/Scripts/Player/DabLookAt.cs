using UnityEngine;

public class DabLookAt : MonoBehaviour
{
    [HideInInspector]
    public Vector3 LookAtRotation;

    public DabController DabController;

    public GameObject TargetFighter;

    void Rotate()
    {
        if (TargetFighter != DabController.Cache.Targetfighter && DabController.Cache.Targetfighter != null)
            TargetFighter = DabController.Cache.Targetfighter;

        if (TargetFighter != null && DabController.Cache.hasTarget == true)
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
