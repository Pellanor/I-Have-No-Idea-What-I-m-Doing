using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupOpener : MonoBehaviour
{
    public GameObject Popup;
    public DialogEngine dialogEngine;

    private void ChangePopup(bool value)
    {
        if (Popup != null) {
            Animator animator = Popup.GetComponent<Animator>();
            if (animator != null) {
                animator.SetBool("open", value);
            }
            Text text = Popup.GetComponentInChildren<Text>();
            text.text = dialogEngine.getConversation("testKey").getLines()[0].getText();
        }
    }

    public void TogglePopup()
    {
        if (Popup != null) {
            Animator animator = Popup.GetComponent<Animator>();
            Debug.Log(animator.GetBool("open"));
            if (animator != null) {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
            Text text = Popup.GetComponentInChildren<Text>();
            text.text = dialogEngine.getConversation("testKey").getLines()[0].getText();

        }
    }

    public void OpenPopup()
    {
        this.ChangePopup(true);
    }

    public void ClosePopup()
    {
        this.ChangePopup(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
