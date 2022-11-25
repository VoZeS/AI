using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Thief Seeing Policeman?")]
[Help("Checks if thief has the policeman at a danerous distance.")]
public class thiefSeesPolicemanCondition : ConditionBase
{
    [InParam("blackboard")]
    public GameObject blackboard;

    public override bool Check()
    {
        GameObject thief = GameObject.Find("Robber");
        GameObject policeman = GameObject.Find("Cop");

        Behaviorblackboard bhblackboard = blackboard.GetComponent<Behaviorblackboard>();

        if (Vector3.Distance(thief.transform.position, policeman.transform.position) >= 15f && bhblackboard.timer <= 3f && !bhblackboard.hasRobbed)
        {
            bhblackboard.timer += Time.deltaTime;
            return true;
        }
        else
        {
            bhblackboard.robberText.gameObject.SetActive(false);
            bhblackboard.hasRobbed = true;

        }
        return false;

    }
}
