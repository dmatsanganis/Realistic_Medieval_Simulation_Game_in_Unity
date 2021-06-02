using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Interactable
{
    public HUD hud;
    public Vector3 PickPosition;
    public Vector3 PickRotation;
    public GameObject Hand;

    public override void OnInteract()
    {
		//action panel has now new message
        hud.StartCoroutine(hud.OpenActionPanel("You are drinking the potion."));
		//now our player has new TaskLevel
        GameObject.FindWithTag("Player").GetComponent<Character>().TaskLevel = MinTaskLevel + 1;
		//quest panel has now new message
        hud.SetQuestPanel(Quest.quest[MinTaskLevel + 1]);
        gameObject.transform.parent = Hand.transform;
        gameObject.transform.localPosition = PickPosition;
        gameObject.transform.localEulerAngles = PickRotation;
		//attach potion to hands
        GameObject.FindWithTag("Player").GetComponent<FootSteps>().InHandObject = gameObject;
        GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("drink");
    }
}

