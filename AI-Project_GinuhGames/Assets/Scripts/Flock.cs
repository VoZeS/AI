using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager myManager;

    public float speed = 10.0f;
    public Vector3 direction;
    private Vector3 liderDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Cohesion();
        Align();
        Separation();*/
        



        if (Vector3.Distance(myManager.lider.transform.position, myManager.runner.transform.position) < 10)
        {
            myManager.lider.transform.position = myManager.runner.transform.position;

        }
        if (Vector3.Distance(myManager.initialPoint.transform.position, myManager.runner.transform.position)>60)
        {
            myManager.lider.transform.position = myManager.initialPoint.transform.position;
        }


        liderDistance = myManager.lider.transform.position - transform.position;

        direction = (Cohesion() + Align() + Separation() + liderDistance).normalized * speed;

        transform.rotation = Quaternion.Slerp(transform.rotation,
                                      Quaternion.LookRotation(direction),
                                      myManager.rotationSpeed * Time.deltaTime);

        //transform.Translate(myManager.lider.transform.position.x, myManager.lider.transform.position.y, Time.deltaTime * speed);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);

    }
    Vector3 Cohesion()
    {
        Vector3 cohesion = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            cohesion = (cohesion / num - transform.position).normalized * speed;

        }

        return cohesion;
    }

    Vector3 Align()
    {
        Vector3 align = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    align += go.GetComponent<Flock>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }

        return align;
    }

    Vector3 Separation()
    {
        Vector3 separation = Vector3.zero;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                    separation -= (transform.position - go.transform.position) /
                                  (distance * distance);
            }
        }

        return separation;
    }
}
