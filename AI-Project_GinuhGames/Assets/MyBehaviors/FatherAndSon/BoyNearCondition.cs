using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Boy Near Father?")]
[Help("Checks whether Boy is near the Father.")]
public class IsBoyNearFather : ConditionBase
{
    public override bool Check()
    {
        GameObject boy = GameObject.Find("Kid");
        GameObject father = GameObject.Find("Father");
        return Vector3.Distance(boy.transform.position, father.transform.position) < 2f;
    }
}