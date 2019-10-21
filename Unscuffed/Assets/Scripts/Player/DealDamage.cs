using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float DamageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D && collision.gameObject.GetComponent<Actor>())
        {
            collision.gameObject.GetComponentInParent<HealthGetSet>().TakeDamage(DamageAmount);
        }
    }
}