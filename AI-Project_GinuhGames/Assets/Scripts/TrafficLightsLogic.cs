using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrafficLightsLogic : MonoBehaviour
{
    public Light TL_Pedestrian_Red_L_Front;
    public Light TL_Pedestrian_Red_R_Front;
    public Light TL_Pedestrian_Green_L_Front;
    public Light TL_Pedestrian_Green_R_Front;
    public Light TL_Pedestrian_Red_L_Back;
    public Light TL_Pedestrian_Red_R_Back;
    public Light TL_Pedestrian_Green_L_Back;
    public Light TL_Pedestrian_Green_R_Back;

    public Light TL_Car_Green_Front;
    public Light TL_Car_Red_Front;
    public Light TL_Car_Red_Back;
    public Light TL_Car_Green_Back;

    public NavMeshAgent runner;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        // ---------------------------------------------- Pedestrian
        // Enable Green Lights // Disable Red Lights
        TL_Pedestrian_Green_L_Back.enabled = true;
        TL_Pedestrian_Green_L_Front.enabled = true;
        TL_Pedestrian_Green_R_Front.enabled = true;
        TL_Pedestrian_Green_R_Back.enabled = true;
        TL_Pedestrian_Red_L_Back.enabled = false;
        TL_Pedestrian_Red_L_Front.enabled = false;
        TL_Pedestrian_Red_R_Front.enabled = false;
        TL_Pedestrian_Red_R_Back.enabled = false;

        // ---------------------------------------------- CarLights
        // Enable Red Lights // Disable Green Lights
        TL_Car_Green_Back.enabled = false;
        TL_Car_Green_Front.enabled = false;
        TL_Car_Red_Front.enabled = true;
        TL_Car_Red_Back.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // PEDESTRIAN: Green Lights Off // Red Lights On
        if(TL_Pedestrian_Green_L_Back.enabled == false &&
        TL_Pedestrian_Green_L_Front.enabled == false &&
        TL_Pedestrian_Green_R_Front.enabled == false &&
        TL_Pedestrian_Green_R_Back.enabled == false &&
        TL_Pedestrian_Red_L_Back.enabled == true &&
        TL_Pedestrian_Red_L_Front.enabled == true &&
        TL_Pedestrian_Red_R_Back.enabled == true &&
        TL_Pedestrian_Red_R_Front.enabled == true)
        {
            // CARS: Green Lights On // Reds Lights Off
            TL_Car_Green_Back.enabled = true;
            TL_Car_Green_Front.enabled = true;
            TL_Car_Red_Back.enabled = false;
            TL_Car_Red_Front.enabled = false;

            runner.areaMask = NavMesh.GetAreaFromName("PedestrianPass");

            if (timer >= 5)
            {
                // PEDESTRIAN: Green Lights On // Red Lights Off
                TL_Pedestrian_Green_L_Back.enabled = true;
                TL_Pedestrian_Green_L_Front.enabled = true;
                TL_Pedestrian_Green_R_Front.enabled = true;
                TL_Pedestrian_Green_R_Back.enabled = true;

                TL_Pedestrian_Red_L_Back.enabled = false;
                TL_Pedestrian_Red_L_Front.enabled = false;
                TL_Pedestrian_Red_R_Back.enabled = false;
                TL_Pedestrian_Red_R_Front.enabled = false;

                // CARS: Green Lights Off // Reds Lights On
                TL_Car_Green_Back.enabled = false;
                TL_Car_Green_Front.enabled = false;
                TL_Car_Red_Back.enabled = true;
                TL_Car_Red_Front.enabled = true;

                timer = 0;
            }
        }
        else // PEDESTRIAN: Green Lights On // Red Lights Off
        {
            // CARS: Green Lights Off // Reds Lights On
            TL_Car_Green_Back.enabled = false;
            TL_Car_Green_Front.enabled = false;
            TL_Car_Red_Back.enabled = true;
            TL_Car_Red_Front.enabled = true;

            runner.areaMask = NavMesh.AllAreas;

            if (timer >= 5 &&
                NavMesh.SamplePosition(runner.transform.position, out NavMeshHit hit, 1.0f, NavMesh.GetAreaFromName("PedestrianPass")))
            {
                // PEDESTRIAN: Green Lights Off // Red Lights On
                TL_Pedestrian_Green_L_Back.enabled = false;
                TL_Pedestrian_Green_L_Front.enabled = false;
                TL_Pedestrian_Green_R_Front.enabled = false;
                TL_Pedestrian_Green_R_Back.enabled = false;

                TL_Pedestrian_Red_L_Back.enabled = true;
                TL_Pedestrian_Red_L_Front.enabled = true;
                TL_Pedestrian_Red_R_Back.enabled = true;
                TL_Pedestrian_Red_R_Front.enabled = true;

                // CARS: Green Lights On // Reds Lights Off
                TL_Car_Green_Back.enabled = true;
                TL_Car_Green_Front.enabled = true;
                TL_Car_Red_Back.enabled = false;
                TL_Car_Red_Front.enabled = false;

                timer = 0;
            }
        }
    }
}
