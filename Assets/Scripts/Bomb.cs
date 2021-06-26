using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;

    public void Explode() {
        float explosionDuration = explosionPrefab.GetComponent<ParticleSystem>().main.duration;
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(explosion.gameObject, explosionDuration);
        Destroy(gameObject);

        FindObjectOfType<GameManager>().GameOverWithDelay(1.25f);
    }
}
