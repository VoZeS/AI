using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
using UnityEngine.AI;

[Action("MyActions/Hide")]
[Help("Makes the agent hide to the tagged objects")]
public class HideAction : BasePrimitiveAction
{

    [InParam("Thief")]
    public GameObject thief;

    [InParam("Blackboard")]
    public GameObject blackboard;

    public override TaskStatus OnUpdate()
    {
        Behaviorblackboard hide = blackboard.GetComponent<Behaviorblackboard>();

        hide.Hide(thief);
        return TaskStatus.RUNNING;
    }
}
