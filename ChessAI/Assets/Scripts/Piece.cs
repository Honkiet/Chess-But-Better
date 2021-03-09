using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;
    [SerializeField] float visionDistance = 20.0f;
    [SerializeField] float visionAngle = 30.0f;
    [SerializeField] float dmg = 10f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        if (healthPoints == 0)
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
