using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckCollision : MonoBehaviour
{
    public bool isCurrentlyColliding;
    public bool isCurrentlyCollidingWithAsphalt;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "floor" && col.gameObject.tag != "floorAsphalt")
        {
            isCurrentlyColliding = true;

        }

        if (col.gameObject.tag == "floorAsphalt")
            isCurrentlyCollidingWithAsphalt = true;
    }

    void OnCollisionExit(Collision col)
    {
        isCurrentlyColliding = false;
        isCurrentlyCollidingWithAsphalt = false;

    }

    void Update()
    {
        //if (isCurrentlyCollidingWithAsphalt)
        //{
        //    Debug.Log("Asphalt!");
        //}
        if (isCurrentlyColliding)
        {
            Debug.Log("Colliding!");
        }
    }
}