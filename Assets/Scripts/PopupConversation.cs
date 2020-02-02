using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupConversation : MonoBehaviour
{
    public Text text;
    public GameObject face;
    public PopupOpener opener;
    public DialogEngine engine;

    private JSONNode.Enumerator conversation;

    public void LoadConversation(string conversationKey) {
        conversation = engine.getConversationIter(conversationKey);
        if (conversation.MoveNext()) {
            JSONNode line = conversation.Current.Value;
            text.text = line["text"];
            opener.OpenPopup();
        }
    }

    public void Next() {
        text.text = conversation.Current.Value["text"];
        if (conversation.MoveNext()) {
            text.text = conversation.Current.Value["text"];
        } else {
            opener.ClosePopup();
        }
    }

    
}
