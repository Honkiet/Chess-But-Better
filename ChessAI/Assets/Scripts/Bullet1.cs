using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    //[SerializeField] GameObject explosion;
    [SerializeField] int dmg;
    public GameObject explosion;

    void OnCollisionEnter(Collision col)
    {
        // To do look into Effects particle system

        //GameObject explosionEffect = Instantiate(explosion, this.transform.position, Quaternion.identity);
        //Destroy(explosionEffect, 2f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public int GetDmg()
    {
        return (dmg);
    }
}
