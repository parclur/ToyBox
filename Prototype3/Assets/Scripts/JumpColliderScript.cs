using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpColliderScript : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Jumping");
        if(collision.gameObject.tag == "Player1")
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * push, ForceMode.Impulse);
    }
}
