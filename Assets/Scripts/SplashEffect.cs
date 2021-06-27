using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour {
    private ParticleSystem particleSystem;

    private void Start() {
        particleSystem = GetComponent<ParticleSystem>();
        float duration = particleSystem.main.duration;
        Destroy(gameObject, duration);
    }
}