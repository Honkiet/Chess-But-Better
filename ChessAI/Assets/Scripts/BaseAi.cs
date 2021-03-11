using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class BaseAi : MonoBehaviour
{

    protected NavMeshAgent agent;
    //remove later
    [SerializeField] protected GameObject enemy;
    //rename Units and give each piece a team number or whatever
    List<Transform> enemies;
    [SerializeField] Piece piece;

    protected UnityAction onChase;
    protected UnityAction onAttack;
    protected UnityAction onFlee;
    protected UnityAction onPatrol;
    protected Action<Vector3> onMove;

    //Transform enemyTransform;

    // Start is called before the first frame update
    public virtual void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        enemies = new List<Transform>();
        Debug.Log("1");
    }

    protected List<Transform> GetEnemies()
    {
        return enemies;
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

}

public enum Layer
{
    Enemy = 8
}
