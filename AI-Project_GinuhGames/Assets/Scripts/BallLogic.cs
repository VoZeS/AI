using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < -2f)
            gameObject.transform.position = new Vector3(Random.Range(-30f, 40f),5f,0f);
    }
}
