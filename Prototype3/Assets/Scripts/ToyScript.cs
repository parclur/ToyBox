using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToyScript : MonoBehaviour
{
    private float push = 5;
    [SerializeField] float speed = 2;
    private GameObject player;
    float minDistance = 5;
    float maxDistance = 10;

<<<<<<< HEAD
    public int enemyHealth = 5;
    ParticleSystem meltingParticleSystem;
    public GameObject gameManager;
    GameManager gameManagerScript;
=======
    NavMeshAgent agent;
>>>>>>> e4e53b07674b85785b717d22cc82f708f1d09ad4

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player1");

        meltingParticleSystem = GetComponent<ParticleSystem>();
        gameManagerScript = gameManager.GetComponent<GameManager>();
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
        //Quaternion.Euler(0, transform.localEulerAngles.y, 0);

        //if(Vector3.Distance(transform.position, player.transform.position) >= minDistance)
        //{
        //    transform.position += transform.forward * speed * Time.deltaTime;
        //}

        agent.destination = player.transform.position;
        
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

    public void EnemyHealth()
    {
        enemyHealth--;

        if(enemyHealth > 0)
        {
            meltingParticleSystem.Play();
        }

        if (enemyHealth <= 0)
        {
            Debug.Log("MELTING");
            gameManagerScript.AddPoints(1);
            Destroy(gameObject);
        }
    }
}
