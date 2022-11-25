using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEditor;

[Condition("MyConditions/The police has seen the robbery?")]
[Help("Checks if police was close to the robbery scene whien it happens.")]
public class HasSeenCondition : ConditionBase
{
    [InParam("blackboard")]
    public GameObject blackboard;


    public override bool Check()
    {
        GameObject policeman = GameObject.Find("Cop");
        GameObject thief = GameObject.Find("Robber");

        Behaviorblackboard bhblackboard = blackboard.GetComponent<Behaviorblackboard>();

        if (bhblackboard.hasRobbed && Vector3.Distance(policeman.transform.position, thief.transform.position) <= 15f)
            return true;
        else
            return false;
        
    }
}
