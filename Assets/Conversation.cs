using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Conversation : MonoBehaviour
{
    public string[,] Conversation1 = { { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" } };
    public int ActiveChunk = 0;
    public TextMeshProUGUI TextMain;
    public TextMeshProUGUI TextAnswer1;
    public ConversationNPC NPC;
    public void InitializeConversation()
    {
        for(int i = 0; i < NPC.Questions.Length; i++)
        {
            Conversation1[i, 0] = NPC.Questions[i];
        }
        for (int i = 0; i < NPC.Answers.Length; i++)
        {
            Conversation1[i, 1] = NPC.Answers[i];
        }
        TextMain.text = Conversation1[ActiveChunk, 0];
        TextAnswer1.text = Conversation1[ActiveChunk, 1];
    }

    public void LoadNextChunk()
    {
        ActiveChunk++;
        TextMain.text = Conversation1[ActiveChunk, 0];
        TextAnswer1.text = Conversation1[ActiveChunk, 1];
    }
}
