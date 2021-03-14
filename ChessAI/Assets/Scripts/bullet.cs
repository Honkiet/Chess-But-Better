using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    public float distance;
    public LayerMask whatIsSolid;



    private void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
           // if (hitInfo.collider.CompareTag("Enemy"))
            {
               // Debug.Log("ENEMY MUST TAKE DAMAGE");
                //hitInfo.collider.GetComponent<enemy>().TakeDamage(damage);
            }
           // Destroy(gameObject);
        }

    }
}
