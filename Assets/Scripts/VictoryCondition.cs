using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCondition : MonoBehaviour
{
    public string NextSceneName;
    public GameState.State StateToSet;


    public void DoVictory() {

        GameState.SetState(StateToSet);
        SceneManager.LoadScene(NextSceneName);
    }
}
