using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenPhotograph : MonoBehaviour
{
    private bool photographIsFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        if (photographIsFallen == true)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void MakePhotographFall()
    {
        photographIsFallen = true;
    }
}
