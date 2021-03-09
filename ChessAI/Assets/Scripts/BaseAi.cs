using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAi : MonoBehaviour
{
    
    NavMeshAgent agent;
    [SerializeField] GameObject enemy;

    [SerializeField] Piece piece;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSee(enemy))
        {
            
            Chase(enemy.transform.position);
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

    private bool CanSee(GameObject obj)
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
}
