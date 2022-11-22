using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviorblackboard : MonoBehaviour
{
    
    public int numElders = 5;
    public GameObject[] allElders;
    public Transform robber;

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
}



