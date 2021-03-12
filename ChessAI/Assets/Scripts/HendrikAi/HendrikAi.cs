﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HendrikAi : BaseAi
{
    // Start is called before the first frame update
    //Update is called once per frame
    
    public override void Start()
    {
        base.Start();
        onChase += testChase;
        
    }
    void Update()
    {

        onChase?.Invoke();
        foreach (Transform unit in units)
        {
            if (CanSee(unit.gameObject))
            {
                Chase(unit.position);

                if (unit.GetComponent<Piece>().teamNumber == 1)
                {
                    Debug.Log("Teammate");
                }
                //    //enemyTransform = enemy.transform;
            }


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
    void testChase()
    {

    }
}
