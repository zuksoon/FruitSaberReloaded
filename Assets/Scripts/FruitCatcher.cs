using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCatcher : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
        
        if (other.gameObject.CompareTag("fruit")) {
            FindObjectOfType<GameManager>().AddMiss();
        }
    }
}