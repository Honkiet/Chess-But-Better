using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class David_AI : BaseAiRanged
{
    // Start is called before the first frame update
    //Update is called once per frame
    private float timer = 0;
    GameObject[] players;
    float distance = 900f;

    GameObject goal;
    public override void Start()
    {
        base.Start();
        onChase += testChase;
        players = GameObject.FindGameObjectsWithTag("piece");
        foreach(GameObject player in players)
        {
            if(player.transform.parent.name != transform.parent.name)
            {
                if (Vector3.Distance(player.transform.position, transform.position) < distance)
                {
                    distance = Vector3.Distance(player.transform.position, transform.position);
                    goal = player;
                }
            }
        }

    }
    void Update()
    {
        if (goal == null)
        {
            Debug.Log("Test");
            distance = 900;
            players = GameObject.FindGameObjectsWithTag("piece");
            foreach (GameObject player in players)
            {
                
                if (player.transform.parent.name != transform.parent.name)
                {
                    if (Vector3.Distance(player.transform.position, transform.position) < distance)
                    {
                        distance = Vector3.Distance(player.transform.position, transform.position);
                        goal = player;
                    }
                }
            }
        }
        if (goal != null)
        {
            if (Vector3.Distance(goal.transform.position, transform.position) >= 9)
            {

                Debug.Log("Distance");

                Chase(goal.transform.position);
                Debug.Log(goal.name);
            }
        }
    }
    private void FixedUpdate()
    {
        timer++;
        if (timer >= 60)
        {
            timer = 0;
            if (goal != null)
            {
                if (Vector3.Distance(goal.transform.position, transform.position) <= 9)
                {
                    Fire(projectile);
                }
            }
        }
        else
        {
            Stop();
        }
    }

    private void Patrol()
    {
        if (CanSee(goal))
        {

        }
    }

    private void Chase(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
    private void Stop()
    {
        agent.isStopped = true;
        agent.ResetPath();
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
