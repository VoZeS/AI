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

    [InParam("WanderAgent")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject wanderAgent;


    public override TaskStatus OnUpdate()
    {
        wanderLogic wander = wanderLogic.GetComponent<wanderLogic>();

        NavMeshAgent agent = wanderAgent.GetComponent<NavMeshAgent>();



        wander.WanderBehavior(agent,wanderAgent);

        return TaskStatus.RUNNING;
    }
}
