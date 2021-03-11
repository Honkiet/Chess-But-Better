using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class BaseAi : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] GameObject enemy;
    List<Transform> enemies;

    [SerializeField] Piece piece;

    protected UnityAction onChase;
    Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        enemies = new List<Transform>();
        onChase += testChase;
    }

    protected List<Transform> GetEnemies()
    {
        return enemies;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        switch ((Layer)other.gameObject.layer)
        {
            case Layer.Enemy:
                enemies.Add(other.transform);
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //todo check if its already in the list
        switch ((Layer)other.gameObject.layer)
        {
            case Layer.Enemy:
                enemies.Remove(other.transform);
                break;
            default:
                break;
        }
    }
    void testChase()
    {
        Debug.Log("hee");
    }
    // Update is called once per frame
    void Update()
    {
        if (CanSee(enemy))
        {

            enemyTransform = enemy.transform;
            //Chase(enemy.transform.position);
            onChase?.Invoke();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        
    }

    //private void Chase(Vector3 destination)
    //{
    //    agent.SetDestination(destination);
    //}

    private void RunAway(Vector3 destination)
    {
        Vector3 AwayVector = destination - this.transform.position;
        agent.SetDestination(this.transform.position - AwayVector);
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


}

public enum Layer
{
    Enemy = 8
}
