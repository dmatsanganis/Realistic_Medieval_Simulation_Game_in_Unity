using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject MessagePanel, DialoguePanel, ActionPanel, QuestPanel, LocationPanel;
	//boolean variable that check if message panel is opened
    private bool mIsMessagePanelOpened = false;
	//boo variable that check if dialogue panel is opened
    private bool mIsDialoguePanelOpened = false;

	// bool method for the state of message panel
    public bool IsMessagePanelOpened
    {
        get { return mIsMessagePanelOpened; }
    }

	//bool method for the state of dialogue panel
    public bool IsDialoguePanelOpened
    {
        get { return mIsDialoguePanelOpened; }
    }
	
	//void method for opening message panel
    public void OpenMessagePanel(Interactable item)
    {
		//message panel is active
        MessagePanel.SetActive(true);
		//set the message panel with the interacted text
		//of the interactable item
        MessagePanel.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = item.InteractText;
		//boolean variable mIsMessagePanelOpened is now true
        mIsMessagePanelOpened = true;
    }
	
	//void method for closing message panel
    public void CloseMessagePanel()
    {
		// message panel is not active
        MessagePanel.SetActive(false);
		//boolean variable mIsMessagePanelOpened is now false
        mIsMessagePanelOpened = false;
    }
	
	// void method for opening panel dialogue
    public void OpenDialoguePanel()
    {
		//dialogue panel is active
        DialoguePanel.SetActive(true);
		//boolean variable mIsDialoguePanelOpened is true
        mIsDialoguePanelOpened = true;
    }
	
	//void method for closing dialogue panel
    public void CloseDialoguePanel()
    {
		//dialogue panel is not active
        DialoguePanel.SetActive(false);
		//boolean variable mIsDialoguePanelOpened is no false
        mIsDialoguePanelOpened = false;
    }

    //method which is used in order to render a panel for certain duration
	public IEnumerator OpenActionPanel(string message)
    {
        ActionPanel.SetActive(true);
        ActionPanel.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = message;
		
		//wait 2 seconds and close action panel
        yield return new WaitForSeconds(2);
        ActionPanel.SetActive(false);
    }

    public void SetQuestPanel(string questMessage)
    {
		//set questMessage
        QuestPanel.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = questMessage;
    }

    public void SetLocationPanel(string location)
    {
		//set location message
        LocationPanel.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = location;
    }
}
