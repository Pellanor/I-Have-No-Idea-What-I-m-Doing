using UnityEngine;

public class PopupOpener : MonoBehaviour
{
    public GameObject Popup;
    public DialogEngine dialogEngine;
    private bool isOpen = false;
    private bool toggled = false;
    private bool animStarted = false;

    public void Update() {
        if(toggled) {
            Animator animator = Popup.GetComponent<Animator>();
            if (animStarted) {
                if (!animator.IsInTransition(0)) {
                    toggled = false;
                    animStarted = false;
                    isOpen = animator.GetBool("open");
                }
            } else {
                if (animator.IsInTransition(0)) {
                    animStarted = true;
                }
            }
        }
    }

    private void ChangePopup(bool value)
    {
        if (Popup != null) {
            Animator animator = Popup.GetComponent<Animator>();
            if (animator != null) {
                if (animator.GetBool("open") != value) {
                    animator.SetBool("open", value);
                    toggled = true;
                }
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
                toggled = true;
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

    public bool IsOpen() {
        return isOpen;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
