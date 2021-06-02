using UnityEngine;
using UnityEngine.Events;

public class NPC : Interactable
{
    public Dialogue dialogue;
    public AudioSource AudioSource;
    [SerializeField]
    public AudioClip[] audioClips;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public override void OnInteract()
    {
		//check if dialogue name is equal with "Wizard" and if player TaskLevel is 6
        if(dialogue.name == "Wizard" && GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().TaskLevel == 6) 
        {
			//create new Dialogue with name "Wizard"
            dialogue = new Dialogue();
            dialogue.name = "Wizard";
			//store new sentences in newSentences array
            string[] newSentences = new string[2];
            newSentences[0] = "Finally you found my keys";
            newSentences[1] = "Follow me to my house.";
            dialogue.sentences = newSentences;
            this.MinTaskLevel = 6;
        }
		//start dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(this);
    }

	//void method for HitSoundEffect
    private void HitSoundEffect()
    {
		//check if audioClips lenght is 1
        if(audioClips.Length == 1)
        {
			//select 1st clip and play it
            AudioClip clip = audioClips[0];
            AudioSource.PlayOneShot(clip);
        }
		//otherwise
        else if(audioClips.Length > 1)
        {
			//select a random clip and play it
            AudioClip clip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
            AudioSource.PlayOneShot(clip);
        }
        else
        {
            return;
        }
    }
}
