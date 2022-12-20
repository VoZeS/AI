using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Linq;

public class Hider : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] hidingSpots;
    public GameObject target;

    //public float radius = 10.0f;
    //public float offset = 10.0f;

    //private float watchTimer = 0.0f;
    //public bool wandering;
    //public bool watching;
    // Start is called before the first frame update
    void Start()
    {
        hidingSpots = GameObject.FindGameObjectsWithTag("hide");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Hide();
    }

    //public void Wander()
    //{
    //    watchTimer += Time.deltaTime;

    //    if (wandering)
    //    {
    //        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
    //        localTarget += new Vector3(offset, 0, offset);

    //        Vector3 worldTarget = transform.TransformPoint(localTarget);
    //        worldTarget.y = 0f;

    //        agent.destination = worldTarget;

    //        wandering = false;
    //        watching = true;

    //    }

    //    if (agent.velocity == new Vector3(0.0f, 0.0f, 0.0f) && !wandering)
    //    {
    //        if (watching)
    //        {
    //            watchTimer = 0.0f;
    //            watching = false;

    //        }

    //        else
    //        {
    //            wandering = true;
    //        }
    //    }
    //    else
    //    {
    //        watching = true;
    //    }

    //}
    void Seek(Vector3 target)
    {
        agent.destination = target;
    }

    public void Hide()
    {
        Func<GameObject, float> distance =(hs) => Vector3.Distance(target.transform.position,hs.transform.position);
        GameObject hidingSpot = hidingSpots.Select(ho => (distance(ho), ho)).Min().Item2;
        Vector3 dir = hidingSpot.transform.position - target.transform.position;
        Ray backRay = new Ray(hidingSpot.transform.position, -dir.normalized);
        RaycastHit info;
        hidingSpot.GetComponent<Collider>().Raycast(backRay, out info, 50f);
        Seek(info.point + dir.normalized);
    }
}
