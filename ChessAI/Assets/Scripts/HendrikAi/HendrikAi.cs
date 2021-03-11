using System.Collections;
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
        Debug.Log("2");
    }
    void Update()
    {
        if (CanSee(enemy))
        {

            //enemyTransform = enemy.transform;
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
        Debug.Log("hee");
    }
}
