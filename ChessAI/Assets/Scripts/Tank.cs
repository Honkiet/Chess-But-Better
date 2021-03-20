using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Piece
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;

    [SerializeField]  Transform attackSpot;
    [SerializeField]  float attackRange = 0.5f;
    [SerializeField] float attackCooldown = 1f;

    float timeSinceLastAttack = Mathf.Infinity;

    public void Attack()
    {
        if(timeSinceLastAttack > attackCooldown)
        {
            //play attack animation
            Collider[] hit = Physics.OverlapSphere(attackSpot.position, attackRange);

            foreach (Collider unit in hit)
            {
                Piece hitPiece = unit.GetComponent<Piece>();
                if (hitPiece)
                {
                    hitPiece.TakeDamage(5);
                    //Knockback 
                    //Turn off navmesh + turn on Kinematic Rigidbody then after knockback reverse
                    //hitPiece.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
                }
                Debug.Log("We hit" + unit.name);
            }
            timeSinceLastAttack = 0;
        }
        

    }

    private void OnDrawGizmosSelected()
    {
        if (attackSpot == null)
            return;
        Gizmos.DrawWireSphere(attackSpot.position, attackRange);
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
    }
}
