using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class DialogEngine : MonoBehaviour
{
    [SerializeField]
    private TextAsset dialogJson;
    private JSONNode data;
    private Dictionary<string, Dialog> parsedData = new Dictionary<string, Dialog>();

    void Start()
    {
        data = JSON.Parse(dialogJson.ToString());
    }

    public Dialog getConversation(string conversationKey) {
        if (parsedData.ContainsKey(conversationKey)) {
            return parsedData[conversationKey];
        }
        JSONNode conversation = data[conversationKey];
        Dialog dialog = new Dialog();
        foreach(JSONNode line in conversation.AsArray) {
            dialog.addLine(line["speaker"], line["text"]);
        }
        parsedData.Add(conversationKey, dialog);
        return dialog;
    }
}
