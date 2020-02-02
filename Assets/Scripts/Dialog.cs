using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    List<DialogLine> lines = new List<DialogLine>();
    
    public void addLine(string speaker, string text) {
        lines.Add(new DialogLine(speaker, text));
    }

    public List<DialogLine> getLines() {
        return lines;
    }

    public class DialogLine {
        private string speaker;
        private string text;

        public DialogLine(string speaker, string text) {
            this.speaker = speaker;
            this.text = text;
        }

        public string getSpeaker() {
            return speaker;
        }

        public string getText() {
            return text;
        }
    }
}
