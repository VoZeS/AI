using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander_NavMesh : MonoBehaviour
{
    NavMeshAgent agent;

    public float radius = 10.0f;
    public float offset = 10.0f;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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

        if(agent.velocity == new Vector3(0.0f,0.0f,0.0f))
        {
            float angle = Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
            agent.transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                                              Time.deltaTime);
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
