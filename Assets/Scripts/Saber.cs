using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public enum Hand {
        LEFT,
        RIGHT
    };

    public Hand hand = Hand.LEFT;

    private void OnCollisionEnter(Collision collision) {
        //foreach (ContactPoint contact in collision.contacts)
        // {
        //Debug.DrawRay(contact.point, contact.normal, Color.red);
        //Debug.Log("Test");
        //Debug.Log(collision.gameObject.name);
        //}
        Console.WriteLine("nigtWork");

        if (collision.gameObject.CompareTag("fruit") == true ) {
            //collision.gameObject.GetComponent<Fruit>().Slice();
            Console.WriteLine("work");
            //Destroy(collision.gameObject);

            // FindObjectOfType<GameManager>().AddPoint();

            // TODO add haptics when slice fruit
            // var controller = hand == Hand.LEFT ? SteamVR_Input_Sources.LeftHand : SteamVR_Input_Sources.RightHand;
            // FindObjectOfType<UnityEngine.InputSystem.Haptics>().Pulse(0.1f, 40, 50, controller);
        }

        //if (collision.gameObject.CompareTag("bomb")) {
         //   collision.gameObject.GetComponent<Bomb>().Explode();
       // }
    }
}
