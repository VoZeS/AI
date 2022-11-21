using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
using UnityEngine.AI;

[Action("MyActions/Wander")]
[Help("Walking acoss the map")]

public class Wander : BasePrimitiveAction
{
    [InParam("WanderLogic")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject wanderLogic;


     public override TaskStatus OnUpdate()
    {
        Wander_NavMesh_Simple wander = wanderLogic.GetComponent<Wander_NavMesh_Simple>();

        wander.Wander();

        return TaskStatus.COMPLETED;
    }
}
