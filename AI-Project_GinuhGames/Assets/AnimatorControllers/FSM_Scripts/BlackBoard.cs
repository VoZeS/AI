using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBoard : MonoBehaviour
{
    public float dist2Bench = 10f;
    public float energy = 10f;
    public Transform elder;
    public GameObject bench;
    public Scrollbar energyScroll;

    private void Update()
    {
        energyScroll.size = energy / 20.0f;
    }
}