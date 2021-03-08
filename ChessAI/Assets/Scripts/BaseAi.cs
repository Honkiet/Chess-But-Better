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
        Vector3 distanceFromMeToEnemyVector = Enemy.transform.position - this.transform.position;

        float angleToEnemy = Vector3.Angle(distanceFromMeToEnemyVector, this.transform.forward);

        // if the enemy is inside the distance and inside vision angle
        if (distanceFromMeToEnemyVector.magnitude < visionDistance && angleToEnemy < visionAngle)
        {
            //avoid tilt
            distanceFromMeToEnemyVector.y = 0;
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

    void Chase(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    void RunAway(Vector3 destination)
    {
        Vector3 AwayVector = destination - this.transform.position;
        agent.SetDestination(this.transform.position - AwayVector);
    }
}
