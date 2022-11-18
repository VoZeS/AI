using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Ball BESIDES Boy?")]
[Help("Checks whether Ball is BESIDES the Boy.")]
public class IsBallBesidesBoy : ConditionBase
{
    public override bool Check()
    {
        GameObject boy = GameObject.Find("Kid");
        GameObject ball = GameObject.Find("Ball");
        return Vector3.Distance(boy.transform.position, ball.transform.position) < 2f;
    }
}