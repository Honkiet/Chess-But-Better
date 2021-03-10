using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] float visionDistance = 20.0f;
    [SerializeField] float visionAngle = 30.0f;
    [SerializeField] float dmg = 10f;
    [SerializeField] HealthBar healthBar;


    bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
    }

    public float GetVisionDistance()
    {
        return (visionDistance);
    }

    public float GetVisionAngle()
    {
        return (visionAngle);
    }

}
