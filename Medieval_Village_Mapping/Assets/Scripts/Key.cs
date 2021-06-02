using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public HUD hud;
    public int keyIndex;

    public override void OnInteract()
    {
		//action panel has new message
        hud.StartCoroutine(hud.OpenActionPanel("You found wizard's key."));
        Inventory.keys[keyIndex] = true;
		//now our player has new TaskLevel
        GameObject.FindWithTag("Player").GetComponent<Character>().TaskLevel = MinTaskLevel + 1;
        hud.SetQuestPanel(Quest.quest[MinTaskLevel + 1]);
        Destroy(gameObject);
    }
}
