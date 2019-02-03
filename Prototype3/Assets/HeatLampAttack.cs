using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatLampAttack : MonoBehaviour
{
    public GameObject lightBeamStart;
    public GameObject lightBeamEnd;

    private LineRenderer line;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        // Add a Line Renderer to the GameObject
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightBeamStart != null && lightBeamEnd != null)
        {
            // Update position of the two vertex of the Line Renderer
            line.SetPosition(0, lightBeamStart.transform.position);
            line.SetPosition(1, lightBeamEnd.transform.position);
        }

        //if (Physics.Raycast(lightBeamStart.transform.position, (lightBeamEnd.transform.position - lightBeamStart.transform.position), out hit, maxRange))
        if (Physics.Linecast(lightBeamStart.transform.position, lightBeamEnd.transform.position))
        {
            if (Physics.Raycast(lightBeamStart.transform.position, (lightBeamEnd.transform.position - lightBeamStart.transform.position), out hit))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.transform.GetComponent<ToyScript>().EnemyHealth();
                    hit.transform.gameObject.transform.GetComponent<ToyScript>().MeltEnemy();
                }
            }
        }
    }
}