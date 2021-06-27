using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCatcher : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("fruit")) {
            FindObjectOfType<GameManager>().AddMiss();
        }
    }
}