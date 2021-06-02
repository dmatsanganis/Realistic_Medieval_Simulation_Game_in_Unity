using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;
    public HUD hud;
    private NPC npc;

	//create a queue for storing sentences
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

	//method for displaying next sentence
    private void Update()
    {
		//check if hud is opened and if keyboard input is "SPACE"
        if(hud.IsDialoguePanelOpened && Input.GetKeyDown(KeyCode.Space))
        {
			//display next sentence
            DisplayNextSentence();
        }
    }

	//void method for starting a dialogue
    public void StartDialogue(NPC npcActive)
    {
        npc = npcActive;
		//hud panel is now opened
        hud.OpenDialoguePanel();
        nameText.text = npc.dialogue.name;
		//queue is cleared
        sentences.Clear();
        foreach (string sentence in npc.dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

	//void method for displaying next sentence
    public void DisplayNextSentence()
    {	
		//if length of queue is zero
        if(sentences.Count == 0)
        {
			//EndDialogue method is called
            EndDialogue();
            return;
        }
		
		//get one sentence from the queue
        string sentence = sentences.Dequeue();
		//set dialogue text 
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
		//dialogue panel is now closed
        hud.CloseDialoguePanel();
		//check the TaskLevel level of our player
        if(GameObject.FindWithTag("Player").GetComponent<Character>().TaskLevel < npc.MinTaskLevel + 1)
        {
			//now our player has new TaskLevel
            GameObject.FindWithTag("Player").GetComponent<Character>().TaskLevel = npc.MinTaskLevel + 1;
			//Quest Panel has greater level now
            hud.SetQuestPanel(Quest.quest[npc.MinTaskLevel + 1]);
        }
		
		//if npc's TaskLevel is 6, npc is Wizard
        if(npc.MinTaskLevel == 6 && npc.Name == "Wizard")
        {
			//Wizard is now moving
            npc.GetComponent<Patrol>().moving = true;
        }
    }
}
