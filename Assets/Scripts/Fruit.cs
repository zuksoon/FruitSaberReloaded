using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Fruit : MonoBehaviour
{
    public GameObject slicedVersion;
    // public GameObject splashEffect;
   // private void OnCollisionEnter(Collision collision)
   // {
   //     Console.WriteLine("hit");
   // }

    public void Slice() {
        GameObject sf = Instantiate(slicedVersion, transform.position, transform.rotation);
        Destroy(this.gameObject);
        Destroy(sf, 1f);
        
    }
}