using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;

public class ChatGPTManager : MonoBehaviour
{
    private List<ChatMessage> messages = new List<ChatMessage>();
    private OpenAIApi openAI = new OpenAIApi();

    public async void AskChatGPT(string newText)
    {
        ChatMessage message = new ChatMessage();
        message.Content = newText;
        message.Role = "user";

        messages.Add(message);
        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = "gpt-3.5-turbo";

        var response = await openAI.CreateChatCompletion(request);

        if(response.Choices !=null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            Debug.Log(chatResponse.Content);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
