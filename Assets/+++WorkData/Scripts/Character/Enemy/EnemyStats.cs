using MyBox;
using System;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Health")]
    public float currentHealth;
    public float maxHealth;
    [Header("Attack")]
    public int attackDamage;
    public float attackSpeed;

    bool a;

    public static event Action OnEnemyDied;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public bool TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            return false;
        }

        return true;
    }

    [ButtonMethod]
    public void Die()
    {
        OnEnemyDied?.Invoke();

        DestroyImmediate(gameObject);
    }
}
