using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyScript : MonoBehaviour
{
    private float push = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player1")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * push, ForceMode.Impulse);
            Destroy(this.gameObject);
        }
    }
}
