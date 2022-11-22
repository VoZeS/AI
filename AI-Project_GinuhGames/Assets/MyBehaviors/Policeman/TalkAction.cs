using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/Talk")]
[Help("The cop starts talking to the thief")]
public class TalkAction : BasePrimitiveAction
{
    [InParam("Thief")]
    public GameObject thief;

    [InParam("Policeman")]
    public GameObject policeman;

    private float talkTimer = 0.0f;
    public override TaskStatus OnLatentStart()
    {
        Debug.Log("hola");
        talkTimer = 0.0f;
        return base.OnLatentStart();
        
        
    }

    public override TaskStatus OnUpdate()
    {
        //logica: parem als dos personatges durant 4 segons i despres cadascu marxa a fer wander
        talkTimer = Time.deltaTime;
        if (talkTimer <= 4f)
        {
            Debug.Log(talkTimer);
            return TaskStatus.RUNNING;
        }
        else
            return TaskStatus.COMPLETED;
       
        
    }
}
