using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPuente : MonoBehaviour
{
    public float speed = 0.5f;
    public Transform[] targets;
    public bool moving = false;
    public int actualMovement;

    public void ActivateMovement(int option)
    {
        actualMovement = option;
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        //float step =  speed * Time.deltaTime; // calculate distance to move
        if(moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[actualMovement].position, speed);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, targets[actualMovement].position) < 0.001f)
            {
                // Swap the position of the cylinder.
                //target.position *= -1.0f;
                Debug.Log(":)");
                moving = false;
            }
        }
        
    }
}
