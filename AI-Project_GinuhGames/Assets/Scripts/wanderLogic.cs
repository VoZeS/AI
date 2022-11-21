using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wanderLogic : MonoBehaviour
{
    public float radius = 10.0f;
    public float offset = 10.0f;

    private float watchTimer = 0.0f;
    public bool wandering;
    public bool watching;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WanderBehavior(NavMeshAgent behaviorAgent, GameObject cop)
    {
        watchTimer += Time.deltaTime;

        if (wandering)
        {
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(offset, 0, offset);

            Vector3 worldTarget = cop.transform.TransformPoint(localTarget);
            worldTarget.y = 0f;

            behaviorAgent.destination = worldTarget;

            wandering = false;
            watching = true;

        }

        if (behaviorAgent.velocity == new Vector3(0.0f, 0.0f, 0.0f) && !wandering)
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
}
