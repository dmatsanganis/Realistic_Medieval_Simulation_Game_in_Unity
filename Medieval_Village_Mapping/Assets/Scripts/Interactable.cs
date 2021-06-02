using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
	//string variable Name
    public string Name;
	//string variable InteractText
    public string InteractText;
	//boolean variable for staying after interact
    public bool StayAfterInteract = false;
	//int variable for MinTaskLevel
    public int MinTaskLevel;
    public virtual void OnInteract()
    {

    }
}
