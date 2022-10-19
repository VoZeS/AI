using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSM : MonoBehaviour
{
    NavMeshAgent agent;

    public float radius = 10.0f;
    public float offset = 10.0f;

    bool firstDest = true;
    bool targetCreated = false;

    Vector3 localTarget;
    Vector3 worldTarget;

    private WaitForSeconds wait = new WaitForSeconds(0.05f);   // 1 / 20
    delegate IEnumerator State();
    private State state;

    IEnumerator Start()
    {
        agent = GetComponent<NavMeshAgent>();

        state = Wander;
        while (enabled)
            yield return StartCoroutine(state());
      
    }
    IEnumerator Wander()
    {
        Debug.Log("Wander state");

        agent.speed = 2;


        if (!targetCreated)
        {
            localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(offset, 0, offset);

            worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;

            targetCreated = true;
        }

        if (firstDest || agent.transform.position.Equals(worldTarget))
        {
            agent.destination = worldTarget;
            if(!firstDest)  targetCreated = false;
            firstDest = false;

        }

        Debug.Log(agent.transform.position);
        Debug.Log(worldTarget);
        Debug.Log(agent.transform.position.Equals(worldTarget));
 

        yield return wait;
    }
}
