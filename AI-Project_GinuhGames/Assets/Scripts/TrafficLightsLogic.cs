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

    public NavMeshAgent blueRunner;
    public NavMeshAgent redRunner;
    public NavMeshAgent elder;
    public NavMeshAgent elder2;
    public NavMeshAgent elder3;
    public NavMeshAgent elder4;
    public NavMeshAgent elder5;
    public NavMeshAgent father;
    public NavMeshAgent son;
    public NavMeshAgent cop;
    public NavMeshAgent robber;
    public NavMeshAgent villager;
    public NavMeshAgent zombie1;
    public NavMeshAgent zombie2;
    public NavMeshAgent zombie3;
    public NavMeshAgent witch;

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
        if (TL_Pedestrian_Green_L_Back.enabled == false &&
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

            redRunner.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            blueRunner.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            elder.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            elder2.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            elder3.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            elder4.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            elder5.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            father.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            son.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            cop.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            robber.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            villager.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            zombie1.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            zombie2.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            zombie3.areaMask = NavMesh.GetAreaFromName("PedestrianPass");
            witch.areaMask = NavMesh.GetAreaFromName("PedestrianPass");

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

            redRunner.areaMask = NavMesh.AllAreas;
            blueRunner.areaMask = NavMesh.AllAreas;
            elder.areaMask = NavMesh.AllAreas;
            elder2.areaMask = NavMesh.AllAreas;
            elder3.areaMask = NavMesh.AllAreas;
            elder4.areaMask = NavMesh.AllAreas;
            elder5.areaMask = NavMesh.AllAreas;
            father.areaMask = NavMesh.AllAreas;
            son.areaMask = NavMesh.AllAreas;
            cop.areaMask = NavMesh.AllAreas;
            robber.areaMask = NavMesh.AllAreas;
            villager.areaMask = NavMesh.AllAreas;

            if (timer >= 5 &&
                NavMesh.SamplePosition(blueRunner.transform.position, out NavMeshHit blueHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                && NavMesh.SamplePosition(redRunner.transform.position, out NavMeshHit redHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                && NavMesh.SamplePosition(elder.transform.position, out NavMeshHit elderHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                 && NavMesh.SamplePosition(elder2.transform.position, out NavMeshHit elder2Hit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                  && NavMesh.SamplePosition(elder3.transform.position, out NavMeshHit elder3Hit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                   && NavMesh.SamplePosition(elder4.transform.position, out NavMeshHit elder4Hit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                    && NavMesh.SamplePosition(elder5.transform.position, out NavMeshHit elder5Hit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                     && NavMesh.SamplePosition(father.transform.position, out NavMeshHit fatherHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                      && NavMesh.SamplePosition(son.transform.position, out NavMeshHit sonHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                      && NavMesh.SamplePosition(cop.transform.position, out NavMeshHit copHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                      && NavMesh.SamplePosition(robber.transform.position, out NavMeshHit robberHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                      && NavMesh.SamplePosition(villager.transform.position, out NavMeshHit villagerHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                      && NavMesh.SamplePosition(zombie1.transform.position, out NavMeshHit zombie1Hit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                      && NavMesh.SamplePosition(zombie2.transform.position, out NavMeshHit zombie2Hit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                      && NavMesh.SamplePosition(zombie3.transform.position, out NavMeshHit zombie3Hit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass"))
                      && NavMesh.SamplePosition(witch.transform.position, out NavMeshHit witchHit, 2.0f, NavMesh.GetAreaFromName("PedestrianPass")))
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
