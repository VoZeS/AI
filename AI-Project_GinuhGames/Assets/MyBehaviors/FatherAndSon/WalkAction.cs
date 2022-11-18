using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
using UnityEngine.AI;

[Action("MyActions/Walk")]
[Help("Persecution")]
public class Walk : BasePrimitiveAction
{
    [InParam("WalkLogic")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject walkLogic;

    public override TaskStatus OnUpdate()
    {
        WalkFather walk = walkLogic.GetComponent<WalkFather>();

        walk.WalkFollowPath();

        return TaskStatus.COMPLETED;
    }
}