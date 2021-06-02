using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{	
    public HUD hud;
	//interactable item 
    private Interactable mInteractItem = null;
	//point of rayCast
    [SerializeField]
    private Transform rayCastPoint;
	//boolean variable that check if player looks at an object
    private bool activateLooking = false;
	//boolean variable that check if player found an object
    private bool found = false;
	//integer variable in which task level is store
    public int TaskLevel;

	// Update is called once per frame
    private void Update()
    { 
        if (found && mInteractItem != null && Input.GetKeyDown(KeyCode.E))
        {
            activateLooking = false;
            mInteractItem.OnInteract();
            if (mInteractItem.StayAfterInteract)
            {
                hud.OpenMessagePanel(mInteractItem);
            }   
            else
            {
                hud.CloseMessagePanel();
                mInteractItem = null;
            }
        }
    }

	//void method which is called when "enter" in a collider
    private void OnTriggerEnter(Collider other)
    {
		//variable activateLooking is now true
        activateLooking = true;
		
		//check if a new location is detected
        Location location = other.GetComponent<Location>();
        if (location != null)
        {
			//location panel message is updated
            hud.SetLocationPanel(location.LocationEnter);
        }
    }

	//void method which is called when "stay" in a collider
    private void OnTriggerStay(Collider other)
    {
        Interactable item = other.GetComponent<Interactable>();
		//check if LookingInteractable is true, item is not null and TaskLevel is greater or equal than MinTaskLevel
        if (LookingInteractable() && item != null && activateLooking && TaskLevel >= item.MinTaskLevel)
        {
			//mInteractItem is now item
            mInteractItem = item; 
			//message panel is now opened
            hud.OpenMessagePanel(mInteractItem);
			//activateLooking is now false
            activateLooking = false;
			//variable found is true
            found = true;
        }   
		//otherwise
        else if(!LookingInteractable())
        {
			//activateLooking is now true
            activateLooking = true;
			//variable found is false
            found = false;
			//mInteractItem is null
            mInteractItem = null;
			//message panel is now closed
            hud.CloseMessagePanel();
			//dialogue panel is now closed
            hud.CloseDialoguePanel();
        }
    }

	//void method which is called when "exit" in a collider
    private void OnTriggerExit(Collider other)
    {
        Interactable item = other.GetComponent<Interactable>();
		//check if item is not null
        if (item != null)
        {
			//message panel is now closed
            hud.CloseMessagePanel();
			//mInteractItem is null
            mInteractItem = null;
			//dialogue panel is now closed
            hud.CloseDialoguePanel();
        }

        Location location = other.GetComponent<Location>();
		//if location is not null
        if (location != null)
        {
			//location panel message is updated
            hud.SetLocationPanel(location.LocationExit);
        }
    }

	//bool method that check if player looks at an interactable object
    private bool LookingInteractable()
    {
		//draw rays
        Debug.DrawRay(rayCastPoint.position, Camera.main.transform.forward * 100, Color.red, 1f);
		//create a new rayCastPoint
        Ray ray = new Ray(rayCastPoint.position, Camera.main.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100))
        {
			//if ray "hits" an interactable object then return true 
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                return true;
            }
        }
        return false;
    }
}
    