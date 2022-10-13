using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander_NavMesh : MonoBehaviour
{
    NavMeshAgent agent;

    public float radius = 10.0f;
    public float offset = 10.0f;

    private float watchTimer = 0.0f;
    private bool wandering;
    private bool watching;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<Animator>().enabled = false;

        wandering = true;
        watching = true;
    }

    // Update is called once per frame
    void Update()
    {
        watchTimer += Time.deltaTime;
        
        if (wandering)
        {
            Wander();
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

            if (watchTimer <= 1.9f)
            {
                GetComponent<Animator>().enabled = true;

                GetComponent<Animator>().Play("WatchCop");

            }
            else
            {
                wandering = true;
            }
        }
        else
        {
            GetComponent<Animator>().enabled = false;
            watching = true;
        }

    }


    void Wander()
    {
        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(offset, 0, offset);

        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
        
        agent.destination = worldTarget;
    }
}
