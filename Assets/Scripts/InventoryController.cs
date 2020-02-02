using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private GameController gameController;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject eye;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.hasLeftArm) {
            leftArm.GetComponent<Image>().color = new Color (1, 1, 1, 1); 
        } else {
            leftArm.GetComponent<Image>().color = new Color (1, 1, 1, 0); 
        }
        
        if (gameController.hasRightArm) {
            rightArm.GetComponent<Image>().color = new Color (1, 1, 1, 1); 
        } else {
            rightArm.GetComponent<Image>().color = new Color (1, 1, 1, 0); 
        }
        
        if (gameController.hasEye) {
            eye.GetComponent<Image>().color = new Color (1, 1, 1, 1); 
        } else {
            eye.GetComponent<Image>().color = new Color (1, 1, 1, 0); 
        }
        
        if (gameController.hasWeapon) {
            weapon.GetComponent<Image>().color = new Color (1, 1, 1, 1); 
        } else {
            weapon.GetComponent<Image>().color = new Color (1, 1, 1, 0); 
        }
    }
}
