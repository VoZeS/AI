using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject beePrefab;
    public int numBee = 10;
    public float neighbourDistance = 20.0f;
    public float minSpeed = 5.0f;
    public float maxSpeed = 20.0f;
    public float rotationSpeed = 5.0f;

    public GameObject[] allBee;

    public GameObject lider;
    public GameObject runner;
    public GameObject initialPoint;

    // Start is called before the first frame update
    void Start()
    {
        allBee = new GameObject[numBee];

        for (int i = 0; i < numBee; ++i)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f)); // random position
            Vector3 randomize = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f)); // random vector direction

            allBee[i] = (GameObject)Instantiate(beePrefab, pos,
                                Quaternion.LookRotation(randomize));
            allBee[i].GetComponent<Flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
