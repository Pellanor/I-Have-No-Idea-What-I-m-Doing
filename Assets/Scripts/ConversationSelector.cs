using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationSelector : MonoBehaviour
{
    [System.Serializable]
    public struct ConversationState {
        public GameState.State state;
        public string conversationKey;
    }
    public ConversationState[] conversations;
    
    public string getConversation(string defaultKey) {
        foreach(ConversationState conv in conversations) {
            if (GameState.IsState(conv.state)) {
                return conv.conversationKey;
            }
        }
        return defaultKey;
    }
}
