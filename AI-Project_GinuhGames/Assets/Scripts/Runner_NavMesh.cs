using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runner_NavMesh : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;

    public Vector3 limit;

    private int hits = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();

    }

    void Run()
    {
        Vector3 distance = target.transform.position - transform.position;

        if (distance.magnitude > limit.magnitude)
        {

            agent.destination = target.transform.position;

        }
        else
        {
            hits++;
            //Debug.Log(hits);
        }

        switch (hits)
        {
            case 0:
                target.transform.position = new Vector3(-25.0f, 0.5f, -10.0f);

                break;
            case 1:
                target.transform.position = new Vector3(0.0f, 0.5f, -13.0f);

                break;
            case 2:
                target.transform.position = new Vector3(25.0f, 0.5f, -13.0f);

                break;
            case 3:
                target.transform.position = new Vector3(35.0f, 0.5f, -13.0f);

                break;
            case 4:
                target.transform.position = new Vector3(40.0f, 0.5f, 12.5f);

                break;
            case 6:
                target.transform.position = new Vector3(25.0f, 0.5f, 14.5f); // BREAK

                break;
            case 7:
                target.transform.position = new Vector3(0.0f, 0.5f, 14.5f);

                break;
            case 8:
                target.transform.position = new Vector3(-20.0f, 0.5f, 14.5f);

                break;
            case 9:
                hits = -1;
                break;
        }
    }
}
