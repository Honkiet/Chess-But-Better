using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Piece
{

    [SerializeField] float timebtw;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform firePoint;
    [SerializeField] float shootPower = 400f;
    // Start is called before the first frame update

    private void Fire()
    {
        GameObject bullet = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * shootPower);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
       // InvokeRepeating("Fire", timebtw, timebtw);
    }
 
}
