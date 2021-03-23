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
    //rename Units and give each piece a team number or whatever
    protected List<Transform> units;

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
        units = new List<Transform>();

    }

    public List<Transform> GetUnitsList()
    {
        return units;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        //add if not in the list already
        if (!units.Contains(other.gameObject.transform))
        {
            switch ((Layer)other.gameObject.layer)
            {
                case Layer.Enemy:
                    units.Add(other.transform);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //remove if in the list
        if (units.Contains(other.gameObject.transform))
        {
            switch ((Layer)other.gameObject.layer)
            {
                case Layer.Enemy:
                    units.Remove(other.transform);
                    break;
                default:
                    break;
            }
        }


    }

}


public enum Layer
{
    Enemy = 8
}
