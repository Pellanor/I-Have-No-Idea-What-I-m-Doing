using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private GameController gameController;
    public void ChangeScene(string name) {
        DontDestroyOnLoad(gameController);
        SceneManager.LoadScene(name);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
}
