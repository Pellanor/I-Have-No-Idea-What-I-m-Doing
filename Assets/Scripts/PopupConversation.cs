using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupConversation : MonoBehaviour
{
    public Text text;
    public Image face;
    public PopupOpener opener;
    public DialogEngine engine;

    [System.Serializable]
    public struct NamedImage {
        public string name;
        public Sprite image;
    }
    public NamedImage[] pictures;

    private JSONNode.Enumerator conversation;
    private Dictionary<string, Sprite> faces = new Dictionary<string, Sprite>();

    public void Start() {
        if (faces.Count == 0)
        {
            foreach (NamedImage pic in pictures)
            {
                faces.Add(pic.name, pic.image);
            }
        }
    }

    public void Update() { 

        if (opener.IsOpen() && Input.GetMouseButtonDown(0)) {
            Next();
        }
        
    }

    public void LoadConversation(string conversationKey) {
        if (faces.Count == 0)
        {
            foreach (NamedImage pic in pictures)
            {
                faces.Add(pic.name, pic.image);
            }
        }
        Debug.Log("Loading: " + conversationKey);
        conversation = engine.getConversationIter(conversationKey);
        if (conversation.MoveNext()) {
            JSONNode line = conversation.Current.Value;
            text.text = line["text"];
            face.sprite = getSprite(line["speaker"]);
            opener.OpenPopup();
        }
    }

    public void Next() {
        if (opener.IsOpen()) {
            JSONNode line = conversation.Current.Value;
            text.text = line["text"];
            face.sprite = getSprite(line["speaker"]);
            if (conversation.MoveNext()) {
                line = conversation.Current.Value;
                text.text = line["text"];
                face.sprite = getSprite(line["speaker"]);
            } else {
                opener.ClosePopup();
            }
        }
    }

    private Sprite getSprite(string key) {
        if (faces.ContainsKey(key.ToLower())) {
            return faces[key.ToLower()];
        }
        return faces["harry"];
    }
    
}
