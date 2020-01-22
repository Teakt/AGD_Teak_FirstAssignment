using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{

    public GameObject target;
    Transform target_transform;
    // Start is called before the first frame update
    public float m_maxVelocity;

    //acceleration in unity units per second
    public float m_acceleration;

    //deccelaration speed with respect to acceleration speed
    public float m_deccelerationMultiplier;

    //rotation speed
    public float rotationDegreesPerSecond = 360;

    // the current velocity
    float _velocity;

    void Start()
    {
        target_transform = target.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target_transform.position  -  transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = m_maxVelocity * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);

        if (_velocity < m_maxVelocity) // GOTTA GO FAST
        {
            _velocity += m_acceleration * Time.deltaTime;
            if (_velocity > m_maxVelocity)
                _velocity = m_maxVelocity;
        }

        transform.position += transform.forward * Time.deltaTime * _velocity;
    }
}
