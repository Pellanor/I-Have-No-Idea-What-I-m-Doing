using UnityEngine;

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
