using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public PopupConversation popup;
    public Animator anim;
    public GameObject roomLight;
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        if(GameState.IsState(GameState.State.GENERATOR_RUNNING))
        {
            anim.enabled = true;
            anim.SetTrigger("jezebelStands");
            popup.LoadConversation("final_sequence");
            GameState.SetState(GameState.State.FINAL_STATE);

        }
        if(GameState.IsState(GameState.State.GENERATOR_RUNNING))
        {
            roomLight.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.IsState(GameState.State.FINAL_STATE))
        {
            if (popup.opener.IsOpen() == true)
            {
                GameState.SetState(GameState.State.FINAL_FINAL_STATE);
            }
        }

        if (GameState.IsState(GameState.State.FINAL_FINAL_STATE))
        {
            if (popup.opener.IsOpen() == false)
            {
                anim.SetTrigger("jezebelAttacks");
                StartCoroutine(EndScreenDelay());
                SceneManager.LoadScene("GameOver");
            }
        }
        
    }
    IEnumerator EndScreenDelay()
    {
        yield return new WaitForSeconds(5);
    }
}
