using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Health")]
    public float currentHealth;
    public float maxHealth;
    [Header("Attack")]
    public int attackDamage;
    public float attackSpeed;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            return false;
        }

        return true;
    }
}
