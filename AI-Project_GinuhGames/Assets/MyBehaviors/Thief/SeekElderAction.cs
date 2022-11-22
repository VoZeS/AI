using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/SeekClosestElder")]
[Help("Thief starts going to the closest elder")]

public class SeekElderAction : BasePrimitiveAction
{
    [InParam("Seeker")]
    public GameObject seeker;

    [InParam("blackboard")]
    public GameObject blackboard;

    //En aquest script hem de posar el target agafantlo del blackboaard on hem creat el bubblesort


    public override TaskStatus OnUpdate()
    {
        Seek_NavMesh seek = seeker.GetComponent<Seek_NavMesh>();

        Behaviorblackboard bhblackboard = blackboard.GetComponent<Behaviorblackboard>();

        bhblackboard.SeekClosestElder();




        seek.Seek(targetToSeek);

        if (Vector3.Distance(seeker.transform.position, targetToSeek.transform.position) < 3.0f)
            return TaskStatus.COMPLETED;
        else
            return TaskStatus.RUNNING;
    }
}
