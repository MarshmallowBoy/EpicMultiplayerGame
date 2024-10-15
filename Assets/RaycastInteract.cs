using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastInteract : MonoBehaviour
{
    public Camera Camera;
    public Conversation Conversation;
    public GameObject ConversationDialogue;
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit))
            {
                if (hit.transform.CompareTag("NPC"))
                {
                    ConversationDialogue.SetActive(true);
                    Conversation.NPC = hit.transform.GetComponent<ConversationNPC>();
                    Conversation.InitializeConversation();
                }
                if (hit.transform.CompareTag("Interactable"))
                {
                    hit.transform.GetComponent<WhenInteracted>().Interact();
                }
            }
        }
    }
}
