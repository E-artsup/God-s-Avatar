using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public GameObject dialogueBox;
	public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		dialogueBox.SetActive(true);
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}
