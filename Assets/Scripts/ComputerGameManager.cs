using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComputerGameManager : MonoBehaviour
{
    public AudioClip mouseClick;
    public GameObject loginScreen;
    public GameObject menuScreen; 

    public Texture2D computerMouseCursor;
    CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotspot = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(computerMouseCursor, hotspot, cursorMode);
        loginScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(mouseClick);
        }

        if(GameState.IsState(GameState.State.LOCKER_OPEN))
        {
            menuScreen.GetComponentInChildren<Text>(false).text = "LOCKER IS OPEN";

        }
    }

    public void Login()
    {
        loginScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

    public void ExitComputer()
    {
        SceneManager.LoadScene("Generator Room");
    }

    public void OpenLocker()
    {
        GameState.SetState(GameState.State.LOCKER_OPEN);
    }

    public void Back()
    {
        menuScreen.SetActive(false);
        loginScreen.SetActive(true);
    }

}
