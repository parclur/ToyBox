using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MovementScript : MonoBehaviour
{
    [SerializeField] int speed = 5;
    [SerializeField] float jump = 100;
    [SerializeField] LayerMask groundLayers;

    private Player player;
    public int playerId = 0;

    bool isGrounded = false;
    Rigidbody rb;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            move = new Vector3(Horizontal, 0.0f, Vertical);
            rb.AddForce(move * speed);
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isGrounded = false;
        }

    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Grounded")
        {
            isGrounded = true;
        }
    }
}
