using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
using UnityEngine.AI;

[Action("MyActions/Talk")]
[Help("The cop starts talking to the thief")]
public class TalkAction : BasePrimitiveAction
{
    [InParam("Thief")]
    public GameObject thief;

    [InParam("Policeman")]
    public GameObject policeman;

    [InParam("Blackboard")]
    public GameObject blackboard;

    private float talkTimer = 0.0f;
    private float afterTimer = 0.0f;

    public override TaskStatus OnUpdate()
    {
        NavMeshAgent robber = thief.GetComponent<NavMeshAgent>();
        NavMeshAgent cop = policeman.GetComponent<NavMeshAgent>();
        Behaviorblackboard blackboardText = blackboard.GetComponent<Behaviorblackboard>();

        Debug.Log("talktimer");
        Debug.Log(talkTimer);

        //logica: parem als dos personatges durant 4 segons i despres cadascu marxa a fer wander
        if (Vector3.Distance(robber.transform.position, cop.transform.position) <= 3f)
        {
            talkTimer += Time.deltaTime;

            if (talkTimer <= 4f)
            {
                afterTimer = 0;
                robber.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                cop.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                blackboardText.policeText.gameObject.SetActive(true);
            }
            else
            {
                afterTimer += Time.deltaTime;
                blackboardText.policeText.gameObject.SetActive(false);
                if (afterTimer >= 15.0f)
                {
                    talkTimer = 0.0f;
                }
            }

            return TaskStatus.RUNNING;
        }
        else
            return TaskStatus.COMPLETED;
       
        
    }
}
