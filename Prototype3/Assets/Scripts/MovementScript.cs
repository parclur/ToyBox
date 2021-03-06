﻿using System.Collections;
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

    public Transform cameraFocus;
    public float rootLow;
    public float rootHigh;
    public float cameraPitchSpeed = 1;
    public float cameraRotateSpeed = 1;
    private float push = 5;


    bool isGrounded = false;
    Rigidbody rb;
    Vector3 move;
    Vector2 look;

    public GameObject gameManager;
    GameManager gameManagerScript;
    //PlayerHealth playerHealthScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = ReInput.players.GetPlayer(playerId);

        //gameManagerScript = gameManager.GetComponent<GameManager>();
        //playerHealthScript = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraMovement();
    }

    void CameraMovement()
    {
        look.y = player.GetAxis("LookVertical");
        look.x = player.GetAxis("LookHorizontal");

        //Up and down movement
        if (look.y > 0.2 && cameraFocus.transform.localPosition.y < rootHigh)
        {
            cameraFocus.transform.Translate(Vector3.up * cameraPitchSpeed);
        }
        else if (look.y < -0.2 && cameraFocus.transform.localPosition.y > rootLow)
        {
            cameraFocus.transform.Translate(Vector3.down * cameraPitchSpeed);            
        }

        //Right and left movement
        gameObject.transform.Rotate(Vector3.up * look.x * cameraRotateSpeed);

        Camera.main.transform.LookAt(cameraFocus);
    }

    void Movement()
    {

        move.y = player.GetAxis("Move Vertical");
        //move.x = player.GetAxis("Move Horizontal");
        move = new Vector3(0, 0, move.y);

        if (isGrounded && player.GetButton("ForwardVertical"))
        {
            rb.AddRelativeForce(Vector3.forward * speed);
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isGrounded = false;
        }

    }
    void OnCollisionStay(Collision col)
    {
        if (col.collider.GetType() == typeof(BoxCollider) && col.gameObject.tag == "Enemy")
        {
            // do stuff only for the box collider
            //Destroy(col.gameObject);
        }
        else if (col.collider.GetType() == typeof(SphereCollider) && col.gameObject.tag == "Enemy")
        {
            // do stuff only for the circle collider
            rb.AddForce(Vector3.forward * 2);
            rb.AddForce(Vector3.up * push, ForceMode.Impulse);
        }
        if (col.gameObject.tag == "Grounded")
        {
            isGrounded = true;

            //need to give player points for jumping on enemy
            //gameManagerScript.AddPoints(1);
        }
        
    }
}
