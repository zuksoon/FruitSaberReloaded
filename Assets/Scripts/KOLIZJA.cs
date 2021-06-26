using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOLIZJA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("lol"))
        {
            collision.gameObject.GetComponent<Fruit>().Slice();
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
