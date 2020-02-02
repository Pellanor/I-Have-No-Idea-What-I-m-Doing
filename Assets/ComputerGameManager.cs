using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerGameManager : MonoBehaviour
{
    public AudioClip mouseClick;
    public GameObject loginScreen;
    public GameObject menuScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(mouseClick);
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
        
    }

}
