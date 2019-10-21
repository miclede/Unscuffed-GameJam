using UnityEngine;

public class ActorController : MonoBehaviour
{
    public InputProcessor InputProcessor;

    public MovementProcessor MovementProcessor;

    public AIProcessor AIProcessor;

    public DabController Dab;

    public Actor actor;

    public ActorCache Cache = new ActorCache();

    public Menus menus;

    [HideInInspector]
    public bool stopMove;

    [HideInInspector]
    public bool AllStop;

    [Range(1, 100)]
    public float Speed;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Dab.actor.gameObject)
            stopMove = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == Dab.actor.gameObject)
            stopMove = true;
    }

    private float cooldown = 1f;
    private float available = 0;

    public bool CooldownTimer()
    {
        if (available <= Time.time)
        {
            available = Time.time + cooldown;

            return true;
        }

        return false;
    }

    void setAsCurrent()
    {
        Dab.TargetFighter(this.gameObject);
        Dab.Cache.hasTarget = true;
    }

    void LookandPosition()
    {
        Cache.Rotation = InputProcessor.LookRotationActor(actor);
        Cache.MoveVector = InputProcessor.getDabPosititon(Dab);
    }

    void PlayAnimation()
    {
        actor.PlayAnimation();
    }

    void Movement()
    {
        if(!AllStop)
        MovementProcessor.MoveActor(Cache.MoveVector, this, Speed);
    }

    void CheckDefeat()
    {
        if (!menus.defeat)
        {
            if (actor.isDefeated)
                menus.victory = true;
        }
    }

    private void Start()
    {
        actor.isDefeated = false;
        setAsCurrent();
    }

    private void Update()
    {
        LookandPosition();
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