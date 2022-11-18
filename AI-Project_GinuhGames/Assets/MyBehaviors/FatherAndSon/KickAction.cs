using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/Kick")]
[Help("Persecution")]
public class Kick : BasePrimitiveAction
{
    [InParam("Ball")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject ball;
    public override TaskStatus OnUpdate()
    {
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();

        ballRB.AddForce(new Vector3(Random.Range(-2000f,2000f), Random.Range(100f, 200f), Random.Range(-1000f, 1000f)));
        
        return TaskStatus.COMPLETED;
    }
}