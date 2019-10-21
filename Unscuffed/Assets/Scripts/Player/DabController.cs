using UnityEngine;

public class DabController : MonoBehaviour
{
    public InputProcessor InputProcessor;

    public MovementProcessor MovementProcessor;

    public Actor actor;

    public Menus menus;

    [Range(1, 100)]
    public float Speed;

    public DabCache Cache = new DabCache();

    void Inputs()
    {
        Cache.MoveInputVector = InputProcessor.getDabMoveInput();
        Cache.LeftClick = Input.GetButtonDown(VarInput.LeftClick);
        Cache.RightClick = Input.GetButtonDown(VarInput.RightClick);
        Cache.Space = Input.GetButtonDown(VarInput.Space);
        Cache.AK47 = Input.GetButtonDown(VarInput.Ak47);
        Cache.C4 = Input.GetButtonDown(VarInput.C4);
    }

    private float cooldown = 2.5f;
    private float available = 0;

    public bool CooldownTimer()
    {
        if (Cache.C4 && available <= Time.time)
        {
            available = Time.time + cooldown;

            return true;
        }

        return false;
    }

    void Movement()
    {
        MovementProcessor.MoveDab(this, Cache.MoveInputVector, Speed);
    }

    void LookRotation()
    {
        Cache.Rotation = InputProcessor.LookRotationDab(actor);
    }

    void PlayAnimation()
    {
        actor.PlayAnimation();
    }

    public void TargetFighter(GameObject target)
    {
        Cache.Targetfighter = target;
    }

    void CheckTarget()
    {
        if (Cache.Targetfighter == null)
        {
            Cache.hasTarget = false;
        }
    }

    void CheckDefeat()
    {
        if (!menus.victory)
        {
            if (actor.isDefeated)
                menus.defeat = true;
        }
        
    }

    private void Start()
    {
        actor.isDefeated = false;

        Time.timeScale = 1;

        if (!actor.canBeHurt)
        {
            actor.canBeHurt = true;
        }
    }

    private void Update()
    {
        Inputs();
        LookRotation();
        CheckTarget();
        CheckDefeat();
    }

    private void FixedUpdate()
    {
        if(!actor.isDefeated)
        Movement();
    }

    private void LateUpdate()
    {
        PlayAnimation();
    }
}
