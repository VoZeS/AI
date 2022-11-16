using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander_NavMesh_Simple : MonoBehaviour
{
    NavMeshAgent agent;

    public float radius = 10.0f;
    public float offset = 10.0f;

    private float watchTimer = 0.0f;
    public bool wandering ;
    public bool watching;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        wandering = true;
        watching = true;

        agent.velocity = new Vector3(0.0f, 0.0f, 5.0f);
    }

    public void Wander()
    {
        watchTimer += Time.deltaTime;

        if (wandering)
        {
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(offset, 0, offset);

            Vector3 worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;

            agent.destination = worldTarget;

            wandering = false;
            watching = true;

        }

        if (agent.velocity == new Vector3(0.0f, 0.0f, 0.0f) && !wandering)
        {
            if (watching)
            {
                watchTimer = 0.0f;
                watching = false;

                // Debug.Log("WatchTimer");
                // Debug.Log(watchTimer);
            }
          //if (watchTimer <= 1.0f)
          //{
          //  Stop();
          //}
            else
            {
                wandering = true;
            }
        }
        else
        {
            watching = true;
        }
    }

    //void Stop()
    //{
    //    agent.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    //}
}
