using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MachineLearningAgent : Agent
{
    Rigidbody rBody;
    CheckCollision checker;
    public TrafficLightsLogic trafficLogic;

    public GameObject floor;
    Bounds floorComplexBounds;
    Bounds floorSimpleBounds;

    private int targetRandomPos = 0;

    private Vector3 lastUpdatePos = Vector3.zero;
    private Vector3 dist;
    private float curentSpeed;

    public float rayDist;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        checker = GetComponent<CheckCollision>();
        floorComplexBounds = new Bounds(floor.transform.position - new Vector3(-8, 0, 8), new Vector3(140, 20, 50));
        floorSimpleBounds = new Bounds(new Vector3(-25f, 0, -15f), new Vector3(30, 20, 30));

    }

    public Transform Target;
    public override void OnEpisodeBegin()
    {
        // If the Agent fell, zero its momentum
        if (this.transform.localPosition.y < -25.5f || !floorSimpleBounds.Contains(this.transform.position))
        {
            //this.rBody.angularVelocity = Vector3.zero;
            //this.rBody.velocity = Vector3.zero;

            // ----------------------------------------------------------------------- Big Complexity
            //this.transform.localPosition = new Vector3(-9f, -24.5f, 82.5f);

            // ----------------------------------------------------------------------- Small Complexity
            this.transform.localPosition = new Vector3(-16.5f, -24.5f, 70.0f);

        }

        targetRandomPos = Random.Range(0, 3);

        // ----------------------------------------------------------------------- Big Complexity
        // switch (targetRandomPos)
        // {
        //     case 0:
        //         Target.localPosition = new Vector3(0, -24.5f, 100);
        //         break;
        //     case 1:
        //         Target.localPosition = new Vector3(45, -24.5f, 85);
        //         break;
        //     case 2:
        //         Target.localPosition = new Vector3(93, -24.5f, 100);
        //         break;
        //     case 3:
        //         Target.localPosition = new Vector3(96, -24.5f, 70);
        //         break;
        //     case 4:
        //         Target.localPosition = new Vector3(45, -24.5f, 70);
        //         break;
        //     case 6:
        //         Target.localPosition = new Vector3(-20, -24.5f, 75);
        //         break;
        //     case 7:
        //         Target.localPosition = new Vector3(8, -24.5f, 83);
        //         break;
        //     case 8:
        //         Target.localPosition = new Vector3(35, -24.5f, 84);
        //         break;
        //     default:
        //         targetRandomPos = Random.Range(0, 8);
        //         break;
        // }

        // ----------------------------------------------------------------------- Small Complexity
        switch (targetRandomPos)
        {
            case 0:
                Target.localPosition = new Vector3(-27.5f, -24.5f, 76.6f);
                break;
            case 1:
                Target.localPosition = new Vector3(-12, -24.5f, 67.7f);
                break;
            case 2:
                Target.localPosition = new Vector3(-16.6f, -24.5f, 82.8f);
                break;
            case 3:
                Target.localPosition = new Vector3(-21.9f, -24.5f, 64.1f);
                break;
            case 4:
                Target.localPosition = new Vector3(-17.1f, -24.5f, 61.5f);
                break;
            case 5:
                Target.localPosition = new Vector3(-9.1f, -24.5f, 82.5f);
                break;
            case 6:
                Target.localPosition = new Vector3(-7.3f, -24.5f, 70.8f);
                break;
            default:
                targetRandomPos = Random.Range(0, 6);
                break;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        //Agent forward
        sensor.AddObservation(transform.forward.x);
        sensor.AddObservation(transform.forward.z);

        // Pedestrian Lights
        //sensor.AddObservation();
    }

    //public float forceMultiplier = 10;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2
        //Vector3 controlSignal = Vector3.zero;
        //controlSignal.x = actionBuffers.ContinuousActions[0];
        //controlSignal.z = actionBuffers.ContinuousActions[1];
        //rBody.AddForce(controlSignal * forceMultiplier);

        switch (actionBuffers.DiscreteActions[0])
        {
            case 0:
                break;
            case 1:
                transform.Translate(0, 0, 5f * Time.deltaTime);
                break;
            case 2:
                transform.Rotate(0, -100 * Time.deltaTime, 0);
                break;
            case 3:
                transform.Rotate(0, 100 * Time.deltaTime, 0);
                break;
            default:
                break;
        }

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached target
        if (distanceToTarget < 3.0f)
        {
            SetReward(1.0f);
            EndEpisode();
        }

        // Has collided

        RaycastHit rayHit;

        if (Physics.Raycast(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.forward, out rayHit, rayDist, LayerMask.GetMask("Obstacle"))
            || Physics.Raycast(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.right, out rayHit, rayDist, LayerMask.GetMask("Obstacle"))
            || Physics.Raycast(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.forward, out rayHit, rayDist, LayerMask.GetMask("Obstacle"))
            || Physics.Raycast(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.right, out rayHit, rayDist, LayerMask.GetMask("Obstacle")))
        {
            
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.forward * rayDist, Color.red);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.right * rayDist, Color.red);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.forward * rayDist, Color.red);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.right * rayDist, Color.red);
            
            //AddReward(-0.02f);

        }
        else
        {
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.forward * rayDist, Color.green);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.right * rayDist, Color.green);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.forward * rayDist, Color.green);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.right * rayDist, Color.green);

        }

        //if (checker.isCurrentlyColliding)
        //{
        //    AddReward(-0.2f);
        //}

        // Crosses in RED
        //if (checker.isCurrentlyCollidingWithAsphalt 
        //    && trafficLogic.TL_Pedestrian_Red_L_Back.enabled
        //    && trafficLogic.TL_Pedestrian_Red_L_Front.enabled 
        //    && trafficLogic.TL_Pedestrian_Red_R_Front.enabled
        //    && trafficLogic.TL_Pedestrian_Red_R_Back.enabled)
        //{
        //    Debug.Log("Crosses RED!!");
        //    AddReward(-0.1f);
        //}

        // Traffic Lights
        
        if ((Physics.Raycast(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.forward, out rayHit, rayDist, LayerMask.GetMask("PedestrianPass"))
            || Physics.Raycast(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.right, out rayHit, rayDist, LayerMask.GetMask("PedestrianPass"))
            || Physics.Raycast(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.forward, out rayHit, rayDist, LayerMask.GetMask("PedestrianPass"))
            || Physics.Raycast(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.right, out rayHit, rayDist, LayerMask.GetMask("PedestrianPass")))
            && trafficLogic.TL_Pedestrian_Red_L_Back.enabled
            && trafficLogic.TL_Pedestrian_Red_L_Front.enabled
            && trafficLogic.TL_Pedestrian_Red_R_Front.enabled
            && trafficLogic.TL_Pedestrian_Red_R_Back.enabled)
        {
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.forward * rayDist, Color.yellow);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), this.transform.right * rayDist, Color.yellow);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.forward * rayDist, Color.yellow);
            Debug.DrawRay(this.transform.position - new Vector3(0.0f, 0.5f, 0.0f), -this.transform.right * rayDist, Color.yellow);

            //AddReward(-0.01f);
        }

        // Is Stopped
        dist = transform.position - lastUpdatePos;
        curentSpeed = dist.magnitude / Time.deltaTime;
        lastUpdatePos = transform.position;

        //Debug.Log(gameObject.name + " movement speed is:" + curentSpeed);

        if (curentSpeed < 0.01f)
        {
            AddReward(-0.005f);
        }

        // Fell off platform
        if (this.transform.localPosition.y < -25.5f || !floorSimpleBounds.Contains(this.transform.position))
        {
            Debug.Log("Reward is -1");
            SetReward(-1.0f);
            EndEpisode();
        }

        Debug.DrawLine(floorSimpleBounds.min, floorSimpleBounds.max, Color.yellow);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //var continuousActionsOut = actionsOut.ContinuousActions;
        //continuousActionsOut[0] = Input.GetAxis("Horizontal");
        //continuousActionsOut[1] = Input.GetAxis("Vertical");

        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            discreteActionsOut[0] = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            discreteActionsOut[0] = 2;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            discreteActionsOut[0] = 3;
        }
    }
}