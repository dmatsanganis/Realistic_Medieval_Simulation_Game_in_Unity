using UnityEngine;

public class Chest : Interactable
{
	//boolean variable that check if chest is open
    private bool IsOpen = false;
	//boolean variable that check if key is in chest
    public bool containKey;
    public int keyIndex;
    public HUD hud;

    public override void OnInteract()
    {
        StayAfterInteract = true;
        InteractText = "Press [E] to ";
        IsOpen = !IsOpen;
        InteractText += IsOpen ? "close" : "open";
		
		//check if chest is open
        if (IsOpen)
        {
			//play sound
            FindObjectOfType<SoundManager>().PlaySound("OpenChest");
			//variable "open" of animator is now true
            GetComponent<Animator>().SetBool("open", true);
        }
        else
        {
			//play sound
            FindObjectOfType<SoundManager>().PlaySound("CloseChest");
			//variable "open" of animator is now true
            GetComponent<Animator>().SetBool("open", false);
        }
		
		//check if key is in chest
        if (containKey)
        {
			//action panel has now new message
            hud.StartCoroutine(hud.OpenActionPanel("You found blacksmith's key."));
            containKey = false;
            Inventory.keys[keyIndex] = true;
			//player has now new TaskLevel
            GameObject.FindWithTag("Player").GetComponent<Character>().TaskLevel = MinTaskLevel + 1;
			//Quest panel has now new quest
            hud.SetQuestPanel(Quest.quest[MinTaskLevel + 1]);
        }
    }
}
