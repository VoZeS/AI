using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander_NavMesh : MonoBehaviour
{
    NavMeshAgent agent;

    public float radius = 10.0f;
    public float offset = 10.0f;

    private float timer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<Animator>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 5.0f)
        {
            Wander();
            timer = 0.0f;
            Debug.Log(timer);
        }
        else if(agent.velocity == new Vector3(0.0f,0.0f,0.0f))
        {
            GetComponent<Animator>().enabled = true;

            GetComponent<Animator>().Play("WatchCop");

        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
    }


    void Wander()
    {
        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(0, 0, offset);

        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
        
        agent.destination = worldTarget;
    }
}
