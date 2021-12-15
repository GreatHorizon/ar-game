using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cannon")
        {
            Destroy(other.gameObject);
            Destroy(this.transform.gameObject);
        }
        else
        {
            Debug.Log("djfklsjfklsdfjklsdfjklsd");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
