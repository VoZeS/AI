using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkFather : MonoBehaviour
{
    NavMeshAgent fatherAgent;
    private GameObject father;
    public GameObject fatherTarget;

    public Vector3 limit;

    private int fatherHits = 0;

    void Start()
    {
        fatherAgent = GetComponent<NavMeshAgent>();
        father = gameObject;
    }

    public void WalkFollowPath()
    {
        Vector3 distance = fatherTarget.transform.position - father.transform.position;

        if (distance.magnitude > limit.magnitude)
        {

            fatherAgent.destination = fatherTarget.transform.position;

        }
        else
        {
            fatherHits++;
            //Debug.Log(hits);
        }

        switch (fatherHits)
        {
            case 0:
                fatherTarget.transform.position = new Vector3(-25.0f, 0.5f, -10.0f);

                break;
            case 1:
                fatherTarget.transform.position = new Vector3(0.0f, 0.5f, -13.0f);

                break;
            case 2:
                fatherTarget.transform.position = new Vector3(25.0f, 0.5f, -13.0f);

                break;
            case 3:
                fatherTarget.transform.position = new Vector3(35.0f, 0.5f, -13.0f);

                break;
            case 4:
                fatherTarget.transform.position = new Vector3(40.0f, 0.5f, 10.5f);

                break;
            case 5:
                fatherTarget.transform.position = new Vector3(25.0f, 0.5f, 14.5f);

                break;
            case 6:
                fatherTarget.transform.position = new Vector3(0.0f, 0.5f, 14.5f);

                break;
            case 7:
                fatherTarget.transform.position = new Vector3(-20.0f, 0.5f, 14.5f);

                break;
            case 8:
                fatherHits = -1;
                break;
        }
    }
}
