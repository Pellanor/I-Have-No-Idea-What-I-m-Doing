using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerChest : MonoBehaviour
{
    Animator anim;
    public AudioSource audio;
    public AudioClip doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(GameState.IsState(GameState.State.LOCKER_OPEN))
        {
            anim.SetTrigger("lockerIsOpening");
            audio.PlayOneShot(doorOpen);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
