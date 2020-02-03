using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void Go() {
        SceneManager.LoadScene("Bedroom");
    }

    public void Exit() {
        Application.Quit();
    }
}
