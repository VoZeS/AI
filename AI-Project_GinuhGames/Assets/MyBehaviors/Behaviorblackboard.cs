using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Behaviorblackboard : MonoBehaviour
{
    
    public int numElders = 5;
    public GameObject[] allElders;
    public Transform robber;
    private GameObject[] hidingSpots;
    public float timer = 0;

    public void SeekClosestElder()
    {
        int i, j;

        GameObject temp;

        float[] distances = new float[numElders];

        for (int b = 0; b < numElders; b++)
        {
            distances[b] = Vector3.Distance(robber.position, allElders[b].transform.position);

        }

        for (i = 0; i < numElders; i++)
        {
            for (j = i + 1; j < numElders; j++)
            {
                if (distances[j] < distances[i])
                {
                    temp = allElders[i];
                    allElders[i] = allElders[j];
                    allElders[j] = temp;
                }
            }
        }
    }
    
    
    private void Seek(Vector3 pos, GameObject robber)
    {
        NavMeshAgent agent = robber.GetComponent<NavMeshAgent>();
        agent.destination = pos;
    }



    public void Hide(GameObject robber)
    {
        hidingSpots = GameObject.FindGameObjectsWithTag("hide");


        Func<GameObject, float> distance =
            (hs) => Vector3.Distance(robber.transform.position,
                                     hs.transform.position);
        GameObject hidingSpot = hidingSpots.Select(
            ho => (distance(ho), ho)
            ).Min().Item2;
        Vector3 dir = hidingSpot.transform.position - robber.transform.position;
        Ray backRay = new Ray(hidingSpot.transform.position, -dir.normalized);
        RaycastHit info;
        hidingSpot.GetComponent<Collider>().Raycast(backRay, out info, 50f);
        Seek(info.point + dir.normalized, robber);
    }
}



