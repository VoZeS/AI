using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runner_NavMesh : MonoBehaviour
{
    NavMeshAgent blueAgent;
    NavMeshAgent redAgent;

    public GameObject blueRunner;
    public GameObject redRunner;

   
    public GameObject blueTarget;
    public GameObject redTarget;

    public Vector3 limit;

    private int blueHits = 0;
    private int redHits = 0;

    // Start is called before the first frame update
    void Start()
    {
        blueAgent = blueRunner.GetComponent<NavMeshAgent>();
        redAgent = redRunner.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       Run();
    }

    void Run()
    {
        BlueRunnerLogic();
        RedRunnerLogic();
    }

    void BlueRunnerLogic()
    {
        Vector3 distance = blueTarget.transform.position - blueRunner.transform.position;

        if (distance.magnitude > limit.magnitude)
        {

            blueAgent.destination = blueTarget.transform.position;

        }
        else
        {
            blueHits++;
            //Debug.Log(hits);
        }

        switch (blueHits)
        {
            case 0:
                blueTarget.transform.position = new Vector3(-25.0f, 0.5f, -10.0f);

                break;
            case 1:
                blueTarget.transform.position = new Vector3(0.0f, 0.5f, -13.0f);

                break;
            case 2:
                blueTarget.transform.position = new Vector3(25.0f, 0.5f, -13.0f);

                break;
            case 3:
                blueTarget.transform.position = new Vector3(35.0f, 0.5f, -13.0f);

                break;
            case 4:
                blueTarget.transform.position = new Vector3(40.0f, 0.5f, 10.5f);

                break;
            case 5:
                blueTarget.transform.position = new Vector3(25.0f, 0.5f, 14.5f);

                break;
            case 6:
                blueTarget.transform.position = new Vector3(0.0f, 0.5f, 14.5f);

                break;
            case 7:
                blueTarget.transform.position = new Vector3(-20.0f, 0.5f, 14.5f);

                break;
            case 8:
                blueHits = -1;
                break;
        }
    }

    void RedRunnerLogic()
    {

        Vector3 distance = redTarget.transform.position - redRunner.transform.position;

        if (distance.magnitude > limit.magnitude)
        {

            redAgent.destination = redTarget.transform.position;

        }
        else
        {
            redHits++;
            //Debug.Log(redHits);

        }

        switch (redHits)
        {
            case 0:
                redTarget.transform.position = new Vector3(90.0f, 0.5f, 10.0f);

                break;
            case 1:
                redTarget.transform.position = new Vector3(26.0f, 0.5f, 15.0f);

                break;
            case 2:
                redTarget.transform.position = new Vector3(0.0f, 0.5f, 15.0f);

                break;
            case 3:
                redTarget.transform.position = new Vector3(-9.0f, 0.5f, -14.0f);

                break;
            case 4:
                redTarget.transform.position = new Vector3(-32.0f, 0.5f, -14.0f);

                break;
            case 5:
                redTarget.transform.position = new Vector3(-33.0f, 0.5f, 13.0f);

                break;
            case 6:
                redTarget.transform.position = new Vector3(33.0f, 0.5f, 13.0f);

                break;
            case 7:
                redTarget.transform.position = new Vector3(39.0f, 0.5f, -15.0f);

                break;
            case 8:
                redTarget.transform.position = new Vector3(75.0f, 0.5f, -18.0f);

                break;
            case 9:
                redHits = -1;
                break;
        }
    }
}
