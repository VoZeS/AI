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

    private float timerRob = 0.0f;
    public override TaskStatus OnUpdate()
    {
        WanderLogic wander = wanderLogic.GetComponent<WanderLogic>();

        NavMeshAgent agent = wanderAgent.GetComponent<NavMeshAgent>();

        Behaviorblackboard bhblackboard = wanderLogic.GetComponent<Behaviorblackboard>();

        if (bhblackboard.hasRobbed)
        {
            bhblackboard.timer = 0;

            timerRob += Time.deltaTime;

            if(timerRob >= 10.0f)
                bhblackboard.hasRobbed = false;
        }
        Debug.Log(bhblackboard.timer);

        wander.WanderBehavior(agent,wanderAgent);

        return TaskStatus.RUNNING;
    }
}
