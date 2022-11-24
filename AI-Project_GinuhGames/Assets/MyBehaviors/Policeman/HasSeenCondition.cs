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

    Behaviorblackboard bhblackboard = blackboard.GetComponent<Behaviorblackboard>();

    public override bool Check()
    {
        GameObject policeman = GameObject.Find("Cop");
        GameObject thief = GameObject.Find("Robber");


        //nom_de_classe nom_variable=blackboard.GetComponent<nom del archiu>();
        if (bhblackboard.isRobbing && Vector3.Distance(policeman.transform.position, thief.transform.position) < 10f)
            return true;
        else
            return false;

        //if(bool robber is active && cop is near (the return line with more distance)
        
        //return true

        //else return false
        
        
    }
}
