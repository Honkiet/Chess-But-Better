using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAi : MonoBehaviour
{
    
    NavMeshAgent agent;
    [SerializeField] GameObject Enemy;

    [SerializeField] float visionDistance = 20.0f;
    [SerializeField] float visionAngle = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
        if (CanSeeEnemy())
        {
            
            Chase(Enemy.transform.position);
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        
    }

    private void Chase(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    private void RunAway(Vector3 destination)
    {
        Vector3 AwayVector = destination - this.transform.position;
        agent.SetDestination(this.transform.position - AwayVector);
    }

    private bool CanSeeEnemy()
    {
        // if the enemy is inside the distance and inside vision angle
        Vector3 distanceFromMeToEnemyVector = Enemy.transform.position - this.transform.position;

        float angleToEnemy = Vector3.Angle(distanceFromMeToEnemyVector, this.transform.forward);

        //if the enemy is not behind walls
        RaycastHit hitInfo;
        Vector3 rayToEnemy = Enemy.transform.position - this.transform.position;

       

        if (Physics.Raycast(this.transform.position, rayToEnemy, out hitInfo))
        {
            //To Do If a teammate is in front the ray hits it first
            if (hitInfo.transform.gameObject.tag == "piece" && distanceFromMeToEnemyVector.magnitude < visionDistance && angleToEnemy < visionAngle)
            { 
                //avoid tilt
                distanceFromMeToEnemyVector.y = 0;
                return true;
            }

        }
        return false;
    }
}
