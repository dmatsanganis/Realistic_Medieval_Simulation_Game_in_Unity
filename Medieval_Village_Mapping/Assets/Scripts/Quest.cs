using UnityEngine;

public class Quest : MonoBehaviour
{
	//static string array with 10 positions
    public static string[] quest = new string[10];

    private void Start()
    {
		//store quests in array
        quest[0] = "Talk to the fisherman at the lake";
        quest[1] = "Talk to the wizard at the village";
        quest[2] = "Talk to the blacksmith's helper";
        quest[3] = "Talk to the blacksmith at the cave";
        quest[4] = "Find the store's key inside the cave";
        quest[5] = "Find the wizard's key inside the store";
        quest[6] = "Talk to the wizard";
        quest[7] = "Follow wizard to his house, get inside and drink the elixir";
        quest[8] = "Completed";
    }
}
