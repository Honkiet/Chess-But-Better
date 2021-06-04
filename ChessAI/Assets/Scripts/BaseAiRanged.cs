using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class BaseAiRanged : BaseAi
{
    //different values
    protected Ranged piece ;
    [SerializeField] float timebtw;

    public GameObject projectile;
    [SerializeField] Transform firePoint;
    [SerializeField] float shootPower = 400f;

    // Start is called before the first frame update
    public override void Start()
    {

        base.Start();
        piece = this.GetComponent<Ranged>();
        
    }

    protected bool CanSee(GameObject obj)
    {
        // if the enemy is inside the distance and inside vision angle
        Vector3 distanceFromMeToObjectVector = obj.transform.position - this.transform.position;

        float angleToObject = Vector3.Angle(distanceFromMeToObjectVector, this.transform.forward);

        //if the enemy is not behind walls
        RaycastHit hitInfo;
        Vector3 rayToObj = obj.transform.position - this.transform.position;



        if (Physics.Raycast(this.transform.position, rayToObj, out hitInfo))
        {
            //To Do If a teammate is in front the ray hits it first
            if (hitInfo.transform.gameObject.tag == "piece" && distanceFromMeToObjectVector.magnitude < piece.GetVisionDistance() && angleToObject < piece.GetVisionAngle())
            {
                //avoid tilt
                distanceFromMeToObjectVector.y = 0;
                return true;
            }

        }
        return false;
    }
    
    

    protected void Fire(GameObject bullet1)
    {
        GameObject bullet = Instantiate(bullet1, firePoint.transform.position, firePoint.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * shootPower);
        Debug.Log("123");

    }

    protected void StopFiring()
    {
       // CancelInvoke("Fire");
    }

    protected void StartFiring()
    {
       // InvokeRepeating("Fire", timebtw, timebtw);
    }
}
