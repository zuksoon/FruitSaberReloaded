using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour {
    public enum Hand {
        LEFT,
        RIGHT
    };

    public Hand hand = Hand.LEFT;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("fruit")) {
            collision.gameObject.GetComponent<Fruit>().Slice();
            FindObjectOfType<GameManager>().AddPoint();
        }
    }
}