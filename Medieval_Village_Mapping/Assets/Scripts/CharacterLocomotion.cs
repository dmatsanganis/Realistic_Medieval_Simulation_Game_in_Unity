using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
	//get a reference of our animator
	Animator animator;
	//a variable to store our input 
    Vector2 input;
	
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		//our horizontal input is assigned to the X component
        input.x = Input.GetAxis("Horizontal");
		//our vertical input is assigned to the Y component
        input.y = Input.GetAxis("Vertical");
		
		//feed x value into our animator
        animator.SetFloat("InputX", input.x);
		//feed y value into our animator
        animator.SetFloat("InputY", input.y);
    }
}
 