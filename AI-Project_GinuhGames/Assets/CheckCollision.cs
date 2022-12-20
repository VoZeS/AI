using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckCollision : MonoBehaviour
{
    public bool isCurrentlyColliding;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "floor")
            isCurrentlyColliding = true;
    }

    void OnCollisionExit(Collision col)
    {
        isCurrentlyColliding = false;
    }

    void Update()
    {
        //if (isCurrentlyColliding)
        //{
        //    Debug.Log("Colliding");
        //}
    }
}