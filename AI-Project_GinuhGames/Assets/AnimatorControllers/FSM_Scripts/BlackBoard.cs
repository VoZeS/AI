using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBoard : MonoBehaviour
{
    public float dist2Bench = 10f;
    public float energy = 10f;
    public Transform elder;
    public int numBenches = 7;
    public GameObject[] allBenches;
    public Scrollbar energyScrollelder1;
    public Scrollbar energyScrollelder2;

    private void Update()
    {
        energyScrollelder1.size = energy / 20.0f;
        energyScrollelder2.size = energy / 20.0f;
    }

    public void LowerDistanceBubbleSort()
    {
        int i, j;

        GameObject temp;

        float[] distances = new float[numBenches];

        for(int b = 0; b < numBenches; b++)
        {
            distances[b] = Vector3.Distance(elder.position, allBenches[b].transform.position);

        }

        for (i = 0; i < numBenches; i++)
        {
            for (j = i + 1; j < numBenches; j++)
            {
                if (distances[j] < distances[i])
                {
                    temp = allBenches[i];
                    allBenches[i] = allBenches[j];
                    allBenches[j] = temp;
                }
            }
        }
    }
}