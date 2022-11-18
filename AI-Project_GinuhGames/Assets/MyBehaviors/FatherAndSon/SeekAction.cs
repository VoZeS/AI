using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/Seek")]
[Help("Persecution")]
public class Seek : BasePrimitiveAction
{
    [InParam("Seeker")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject seeker;

    [InParam("Tarjet")]
    [Help("The GameObject that will get persecuted.")]
    public GameObject targetToSeek;
    public override TaskStatus OnUpdate()
    {
        Seek_NavMesh seek = seeker.GetComponent<Seek_NavMesh>();

        seek.Seek(targetToSeek);

        if (Vector3.Distance(seeker.transform.position, targetToSeek.transform.position) < 3.0f)
            return TaskStatus.COMPLETED;
        else
            return TaskStatus.RUNNING;
    }
}