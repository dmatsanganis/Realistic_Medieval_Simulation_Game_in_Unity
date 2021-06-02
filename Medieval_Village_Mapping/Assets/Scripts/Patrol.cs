using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class Patrol : MonoBehaviour
{
    Animator animator;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;
    public GameObject[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;
	//boolean variable that check if mo is enabled
    public bool moving;
	//boolean va that check if loop is enabled
    public bool loop;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        if (moving)
        {
			//variable "move" of animator is now true
            animator.SetBool("move", true);
			//method GoToNextPoint is called
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
		//if points' length is 0, do nothing
        if (points.Length == 0)
        {
            return;
        }
		//agent's destination is equals to points
        agent.destination = points[destPoint].transform.position;
        if (destPoint == points.Length - 1 && !loop)
        {
            return;
        }
		//destPoint is destPoint + 1 mod the length of points
        destPoint = (destPoint + 1) % points.Length;
    }


    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
			//check if any points are left
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GoToNextPoint();
            }
            Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

            // Map 'worldDeltaPosition' to local space
            float dx = Vector3.Dot(transform.right, worldDeltaPosition);
            float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
            Vector2 deltaPosition = new Vector2(dx, dy);

            // Low-pass filter the deltaMove
            float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
            smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

            // Update velocity if time advances
            if (Time.deltaTime > 1e-5f)
                velocity = smoothDeltaPosition / Time.deltaTime;

            bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

            // Update animation parameters
            animator.SetBool("move", shouldMove);
            animator.SetFloat("velx", velocity.x);
            animator.SetFloat("vely", velocity.y);
            // Pull agent towards characters
            if (worldDeltaPosition.magnitude > agent.radius)
                agent.nextPosition = transform.position + 0.9f * worldDeltaPosition;
        }

    }

    void OnAnimatorMove()
    {
        // Update position based on animation movement using navigation surface height
        Vector3 position = animator.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
    }
}
