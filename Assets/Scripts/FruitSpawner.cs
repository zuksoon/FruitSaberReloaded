using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {
    public GameObject[] fruits;
    public PathCreation.PathCreator[] paths;
    public GameObject bomb;
    public float upForce = 40f;
    public float foForce = 155f;
    [Range(0, 1)] public float bombChance = 0.25f;
    
    private float interpolationPeriod = 1f;
    private float time = 0.0f;
    private float maxSpeed;

    private void Update() {
        time += Time.deltaTime;

        if (time >= interpolationPeriod) {
            time = time - interpolationPeriod;
            SpawnFruit();
        }
    }

    public void SetTimer(float t) {
        interpolationPeriod = t;
    }

    public void ReduceTimer(float t) {
        if (interpolationPeriod - t < maxSpeed) {
            interpolationPeriod = maxSpeed;
        } else {
            interpolationPeriod -= t;
        }
    }

    public void SetMaxSpeed(float t) {
        maxSpeed = t;
    }

    public void setBombChance(float c) {
        bombChance = c;
    }

    void SpawnFruit() {
        GameObject randomFruit = fruits[Random.Range(0, fruits.Length)];
        PathCreation.PathCreator randompath = paths[Random.Range(0, paths.Length)];
        GameObject objectToThrow = (Random.Range(0, 100 - bombChance * 100) == 0) ? Instantiate(bomb, transform.position, Random.rotation) : Instantiate(randomFruit, transform.position, Random.rotation);
        objectToThrow.GetComponent<PathCreation.Examples.PathFollower>().speed = 15;
        objectToThrow.GetComponent<PathCreation.Examples.PathFollower>().pathCreator = randompath;
    }
}