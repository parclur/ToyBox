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

        move.y = player.GetAxis("Move Vertical");
        move.x = player.GetAxis("Move Horizontal");

        if (isGrounded && player.GetButton("Forward"))
        {
            move = new Vector3(move.x, 0.0f, move.y);
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
