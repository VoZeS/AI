using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{

    public GameObject target;
    public Vector3 limit;

    private int hits = 0;

    public float maxVel = 6.0f;
    public float turnSpeed = 6.0f;

    private float actualvel = 0;
    public float acceleration = 1.5f;
    public float deacceleration = -1.5f;

    public float minVelRot = 2.0f;

    private bool breakRot = false;

    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f; // (x, z): position in the floor

        Vector3 movement = direction.normalized * acceleration;

        //Debug.Log(actualvel);

        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);  // up = y

        Vector3 distance = target.transform.position - transform.position;

        if (distance.magnitude < 6)
        {
            if (actualvel > minVelRot && breakRot)
            {
               //Debug.Log("Frenada");

                actualvel += deacceleration * Time.deltaTime;
                actualvel = Mathf.Max(actualvel, minVelRot);
            }
           
        }
        else
        {
            breakRot = false;
            actualvel += acceleration * Time.deltaTime;
            actualvel = Mathf.Min(actualvel, maxVel);
        }

        if (distance.magnitude > limit.magnitude)
        {

            transform.position += transform.forward.normalized * actualvel * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                                              Time.deltaTime * turnSpeed);
        }
        else
        {
            hits++;
            //Debug.Log(hits);
        }

        switch(hits)
        {
            case 0:
                target.transform.position = new Vector3(-25.0f, 0.5f, -10.0f);
                breakRot = true;

                break;
            case 1:
                target.transform.position = new Vector3(3.0f, 0.5f, -10.0f);

                break;
            case 2:
                target.transform.position = new Vector3(25.0f, 0.5f, -10.0f);

                break;
            case 3:
                target.transform.position = new Vector3(43.0f, 0.5f, -10.0f);
                breakRot = true;

                break;
            case 4:
                target.transform.position = new Vector3(43.0f, 0.5f, 10.0f);
                breakRot = true;

                break;
            case 6:
                target.transform.position = new Vector3(25.0f, 0.5f, 10.0f); // BREAK

                break;
            case 7:
                target.transform.position = new Vector3(3.0f, 0.5f, 10.0f);

                break;
            case 8:
                target.transform.position = new Vector3(-25.0f, 0.5f, 10.0f);
                breakRot = true;

                break;
            case 9:
                hits = -1;
                break;
        }
    }
}
