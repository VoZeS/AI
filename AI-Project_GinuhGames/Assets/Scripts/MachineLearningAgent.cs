using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MachineLearningAgent : Agent
{
   // Rigidbody rBody;

    private int targetRandomPos = 0;

    void Start()
    {
        //rBody = GetComponent<Rigidbody>();
    }

    public Transform Target;
    public override void OnEpisodeBegin()
    {
        // If the Agent fell, zero its momentum
        if (this.transform.localPosition.y < -25.5f)
        {
            //this.rBody.angularVelocity = Vector3.zero;
            //this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3(-25.0f, -24.5f, 87.5f);
        }

        targetRandomPos = Random.Range(0, 8);

        switch (targetRandomPos)
        {
            case 0:
                Target.localPosition = new Vector3(0,
                                            -24.5f,
                                            100);
                break;
            case 1:
                Target.localPosition = new Vector3(45,
                                           -24.5f,
                                           85);
                break;
            case 2:
                Target.localPosition = new Vector3(93,
                                           -24.5f,
                                           100);

                break;
            case 3:
                Target.localPosition = new Vector3(96,
                                           -24.5f,
                                           70);

                break;
            case 4:
                Target.localPosition = new Vector3(45,
                                           -24.5f,
                                           70);
                break;
            case 6:
                Target.localPosition = new Vector3(-20,
                                            -24.5f,
                                            75);

                break;
            case 7:
                Target.localPosition = new Vector3(8,
                                           -24.5f,
                                           83);

                break;
            case 8:
                Target.localPosition = new Vector3(35,
                                           -24.5f,
                                           84);

                break;
            default:
                targetRandomPos = Random.Range(0,8);
                break;
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        //Agent velocity
        sensor.AddObservation(transform.forward.x);
        sensor.AddObservation(transform.forward.z);
    }

    public float forceMultiplier = 10;
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
                transform.Translate(0, 0, 200f * Time.deltaTime);
                break;
            case 2:
                transform.Rotate(0, -50 * Time.deltaTime, 0);
                break;
            case 3:
                transform.Rotate(0, 50 * Time.deltaTime, 0);
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

        // Fell off platform
        else if (this.transform.localPosition.y < -25.5f)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //var continuousActionsOut = actionsOut.ContinuousActions;
        //continuousActionsOut[0] = Input.GetAxis("Horizontal");
        //continuousActionsOut[1] = Input.GetAxis("Vertical");

        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 0;

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            discreteActionsOut[0] = 1;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            discreteActionsOut[0] = 2;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            discreteActionsOut[0] = 3;
        }
    }
}