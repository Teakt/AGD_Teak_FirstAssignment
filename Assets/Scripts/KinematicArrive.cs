using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour
{

    public GameObject target;
    Transform target_transform;
    // Start is called before the first frame update
    //public float m_maxVelocity;

    //acceleration in unity units per second
    //public float m_acceleration;

    //deccelaration speed with respect to acceleration speed
    //public float m_deccelerationMultiplier;

    //rotation speed
    public float rotationDegreesPerSecond = 360;

    // the current velocity
    float _velocity;

    //public float slow_speed ; //We set to 10 , the user sets it, below this speed : A. of our exercice
    //public float small_distance; // We set the "small distance" from the target : A.i of our exercice 

    public float speed = 20.0f;
    public float nearSpeed = 10.0f;
    public float nearRadius = 20.0f;
    public float arrivalRadius = 10.0f;
    float distanceFromTarget;

    void Start()
    {
        target_transform = target.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target_transform.position - transform.position;
        /*
        if (_velocity < m_maxVelocity) // GOTTA GO FAST
        {
            _velocity += m_acceleration * Time.deltaTime;
            if (_velocity > m_maxVelocity)
                _velocity = m_maxVelocity;
        }
        */
        distanceFromTarget = (target.transform.position - transform.position).magnitude; // Far from target A.ii
        if (distanceFromTarget > nearRadius) 
        {
            

            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            Debug.DrawRay(transform.position, newDirection, Color.red);

            transform.rotation = Quaternion.LookRotation(newDirection);

            Debug.Log("Outside Near Radius " + distanceFromTarget);
            //Debug.Log("Velocity " + ((target.transform.position - transform.position).normalized * nearSpeed));
            //rb.velocity = ((target.transform.position - transform.position).normalized * speed);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else if ((target.transform.position - transform.position).magnitude > arrivalRadius) // Close to target CHECK A.i.
        {
            Debug.Log("Inside Near Radius " + distanceFromTarget);
            //Debug.Log("Velocity " + ((target.transform.position - transform.position).normalized * nearSpeed));
            //rb.velocity = ((target.transform.position - transform.position).normalized * nearSpeed);
            transform.position += targetDirection * Time.deltaTime * nearSpeed;
        }
        else
        {
            Debug.Log("Inside Arrive Radius " + distanceFromTarget);
            //Debug.Log("Velocity " + ((target.transform.position - transform.position).normalized * nearSpeed));
            //rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            transform.position += transform.forward * Time.deltaTime * 0;
        }

        
    }
}
