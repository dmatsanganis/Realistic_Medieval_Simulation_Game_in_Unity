using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
	//boolean variable that check if door is locked
    public bool isLocked = true;
    public int keyIndex;
	//bool variable that check if  door is open
    public bool IsOpen = false;
    public HUD hud;

    private void Update()
    {
		//interact text is updated
        InteractText = "Press [E] to ";
        InteractText += IsOpen ? "close" : "open";
    }

    public override void OnInteract()
    {
		//check if door is locked
        if (isLocked)
        {
            if (Inventory.keys[keyIndex])
            {
                isLocked = false;
                IsOpen = true;
				//action panel has now new message
                hud.StartCoroutine(hud.OpenActionPanel("You unlocked the door"));
                InteractText = "Press [E] to close";
				//variable "open" of animator is now true
                GetComponent<Animator>().SetBool("open", true);
				//sound "OpenDoor" is now playing
                FindObjectOfType<SoundManager>().PlaySound("OpenDoor");

            }
			
			//in different case
            else
            {
				//check keyIndex
                if (keyIndex == 0)
                {		
                    InteractText = "Door is locked.";
                }
                else
                {
                    InteractText = "Door is locked. Find the key to open it.";
                }
				//sound "LockedDoor" is now playing
                FindObjectOfType<SoundManager>().PlaySound("LockedDoor");
            }
        }
		
		//if door is unlocked
        else
        {
            IsOpen = !IsOpen;
            InteractText = "Press [E] to ";
            InteractText += IsOpen ? "close" : "open";
			
			//if IsOpen
            if (IsOpen)
            {
				//sound "OpenDoor" is now playing
                FindObjectOfType<SoundManager>().PlaySound("OpenDoor");
				//variable "open" of animator is now true
                GetComponent<Animator>().SetBool("open", true);
            }
            else
            {
				//sound "CloseDoor" is now playing
                FindObjectOfType<SoundManager>().PlaySound("CloseDoor");
				//variable "open" of animator is now false
                GetComponent<Animator>().SetBool("open", false);
            }
        }
    }
}
