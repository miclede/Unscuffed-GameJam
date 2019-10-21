using UnityEngine;
using UnityEngine.UI;

public class HealthGetSet : MonoBehaviour
{
    public float health;

    public float maxhealth;

    public Actor actor;

    public Image healthBar;

    public float Health
    {
        get { return (Mathf.Round(health)); }
        set { if (value >= 0) health = Mathf.Round(value); }
    }

    public float DamageToHealth
    {
        set
        {
            if (value >= 0 && health - Mathf.Round(value) >= 0)
                health -= Mathf.Round(value);
            if (value >= 0 && health - Mathf.Round(value) <= 0)
                health = 0;
        }
    }

    public float HealtoHealth
    {
        set
        {
            if (value >= 0 && (health + Mathf.Round(value)) <= maxhealth)
                health += Mathf.Round(value);
        }
    }

    public void TakeDamage(float damage)
    {
        DamageToHealth = damage;
        healthBar.fillAmount = Health / maxhealth;

        if (damage >= 5 && actor.canBeHurt)
        {
            actor.isKnockDown = true;
        }

        if (damage < 5 && actor.canBeHurt && damage > 2)
        {
            actor.isHurt = true;
        }
        
        if (Health == 0)
        {
            Defeated();
        }
    }

    public void Heal(float amount)
    {
        HealtoHealth = amount;
    }

    void Defeated()
    {
        actor.isDefeated = true;
    }

    private void Start()
    {
        Health = maxhealth;
    }
}
