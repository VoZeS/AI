using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject target;
    public Vector3 limit;

    private int hits = 0;

    public int maxVel = 6;
    public int turnSpeed = 6;

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

        Vector3 movement = direction.normalized * maxVel;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);  // up = y

        Vector3 distance = target.transform.position - transform.position;

        if(distance.magnitude > limit.magnitude)
        {

            transform.position += transform.forward.normalized * maxVel * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                                              Time.deltaTime * turnSpeed);
        }
        else
        {
            hits++;
            Debug.Log(hits);
        }

        switch(hits)
        {
            case 0:
                target.transform.position = new Vector3(-6.0f, 0.5f, -10.0f);

                break;
            case 1:
                target.transform.position = new Vector3(10.0f, 0.5f, 10.0f);

                break;
            case 2:
                target.transform.position = new Vector3(10.0f, 0.5f, -10.0f);

                break;
            case 3:
                target.transform.position = new Vector3(-10.0f, 0.5f, -10.0f);
                break;
            case 4:
                hits = -1;
                break;
        }
    }
}
