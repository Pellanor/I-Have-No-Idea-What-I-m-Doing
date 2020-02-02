using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class DialogEngine : MonoBehaviour
{
    [SerializeField]
    public TextAsset dialogJson;
    private JSONNode data;

    void Start()
    {
        data = JSON.Parse(dialogJson.ToString());
    }

    public JSONNode.Enumerator getConversationIter(string conversationKey) {
        JSONNode conversation = data[conversationKey];
        return conversation.GetEnumerator();
    }
}
