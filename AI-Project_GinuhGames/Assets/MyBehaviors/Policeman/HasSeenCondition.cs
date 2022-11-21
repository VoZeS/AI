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
        GameObject boy = GameObject.Find("Kid");
        GameObject father = GameObject.Find("Father");
        
        
        //nom_de_classe nom_variable=blackboard.GetComponent<nom del archiu>();
        

        //if(bool robber is active && cop is near (the return line with more distance)
        
        //return true

        //else return false
        
        return Vector3.Distance(boy.transform.position, father.transform.position) < 2f;
    }
}
