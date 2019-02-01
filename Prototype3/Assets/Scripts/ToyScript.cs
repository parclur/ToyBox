using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyScript : MonoBehaviour
{
    private float push = 5;
    private float speed = 4;
    private GameObject player;
    float minDistance = 5;
    float maxDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //super simple movement would fix later
        transform.LookAt(player.transform);
        if(Vector3.Distance(transform.position, player.transform.position) >= minDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        
    }

    void Seek()
    {
        //Vector3 enemyDirection = target.transform.position - transform.position;
        //enemyDirection.z = 0;
        //float distance = enemyDirection.magnitude;
        //float deecelelrationFactor = distance / deecelerationFactor;
        //float speed = moveSpeed * deecelelrationFactor;

        //Vector3 moveVector = enemyDirection.normalized * Time.deltaTime * speed;
        //transform.position += moveVector;
        //rb.velocity *= moveVector * moveSpeed * Time.deltaTime;
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
