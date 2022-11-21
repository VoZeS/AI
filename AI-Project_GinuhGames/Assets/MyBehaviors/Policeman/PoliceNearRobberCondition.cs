using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Cop BESIDES Thief?")]
[Help("Checks whether policeman is besides thief.")]
public class PoliceNearRobberCondition : ConditionBase
{
    public override bool Check()
    {
        GameObject thief = GameObject.Find("Robber");
        GameObject policeman = GameObject.Find("Cop");
        return Vector3.Distance(thief.transform.position, policeman.transform.position) < 2f;
    }
}
