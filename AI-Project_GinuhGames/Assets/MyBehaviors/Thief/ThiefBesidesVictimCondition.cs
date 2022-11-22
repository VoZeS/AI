using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Thief robbing?")]
[Help("Checks whether thief is besides a victim.")]

public class ThiefBesidesVictimCondition : ConditionBase
{
    public bool isRobbing = false;
    public override bool Check()
    {
        GameObject thief = GameObject.Find("Robber");
        GameObject victim1 = GameObject.Find("Elder");
        GameObject victim2 = GameObject.Find("Elder2");
        GameObject victim3 = GameObject.Find("Elder3");
        GameObject victim4 = GameObject.Find("Elder4");
        GameObject victim5 = GameObject.Find("Elder5");
        

        if (Vector3.Distance(thief.transform.position, victim1.transform.position) < 2f || Vector3.Distance(thief.transform.position, victim2.transform.position) < 2f ||
            Vector3.Distance(thief.transform.position, victim3.transform.position) < 2f || Vector3.Distance(thief.transform.position, victim4.transform.position) < 2f ||
            Vector3.Distance(thief.transform.position, victim5.transform.position) < 2f)
        {
            isRobbing = true;
            return true;
        }
        else
            return false;
    }
}
