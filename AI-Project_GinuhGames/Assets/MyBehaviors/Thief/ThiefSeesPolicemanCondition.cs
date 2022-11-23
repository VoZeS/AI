using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Thief Seeing Policeman?")]
[Help("Checks if thief has the policeman at a danerous distance.")]
public class thiefSeesPolicemanCondition : ConditionBase
{
    public override bool Check()
    {
        GameObject thief = GameObject.Find("Robber");
        GameObject policeman = GameObject.Find("Cop");
        return Vector3.Distance(thief.transform.position, policeman.transform.position) >= 10f;
    }
}
