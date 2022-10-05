using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numFish = 10;
    public float neighbourDistance = 20.0f;
    public float minSpeed = 5.0f;
    public float maxSpeed = 20.0f;
    public float rotationSpeed = 5.0f;

    public GameObject[] allFish;

    public GameObject lider;

    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];

        for (int i = 0; i < numFish; ++i)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f)); // random position
            Vector3 randomize = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f)); // random vector direction

            allFish[i] = (GameObject)Instantiate(fishPrefab, pos,
                                Quaternion.LookRotation(randomize));
            allFish[i].GetComponent<Flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
