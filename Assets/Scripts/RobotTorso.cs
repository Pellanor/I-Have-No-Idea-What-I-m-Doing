using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RobotTorso : MonoBehaviour,
                          IPointerDownHandler,
                          IPointerEnterHandler,
                          IPointerExitHandler
{
    public Inventory Inventory;
    public PopupConversation popup;
    
    Texture2D HandCursor;
    Vector2 HandCursorOffset = new Vector2(5, 5);
    
    // Start is called before the first frame update
    void Start()
    {
        addPhysics2DRaycaster();
        this.HandCursor = (Texture2D)Resources.Load("MouseCursors/grabhand32");
    }

    /**
      * Attaches a 2D Raycaster component to the camera, so pointer handling works
      */
    void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    /**
      * Handle mouse moving onto the robot part.
      * This sets the cursor.
      */
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Cursor entering: " + eventData.pointerCurrentRaycast.gameObject.name);
        Cursor.SetCursor(HandCursor, HandCursorOffset, CursorMode.Auto);
    }

    /**
      * Handles mouse moving off the robot part.
      * This resets the cursor.
      */
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Cursor exiting: " + eventData);
        ResetCursor();
    }

    /** 
      * Handles clicking on this robot piece.
      * If it can be collected into inventory, it sets inventory as destination.
      */
    public void OnPointerDown(PointerEventData eventData)
    {
      if(eventData.button == PointerEventData.InputButton.Left)
      {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);

        string name = this.Inventory.GetCurrentlySelectedName();
        // GameObject selected = this.Inventory.GetCurrentlySelected();
        // RobotPartHandler robotPart = selected.GetComponent<RobotPartHandler>();

        if(name == null || name == "")
        {
          popup.LoadConversation("select_inventory");
        } else if(name == "VoiceChip") {

        } else if(name == "PowerCell") {

        } else if(name == "Arm1") {

        } else if(name == "Arm2") {

        } else if(name == "OpticalSensorArray") {

        } else {
          popup.LoadConversation("cannot_do");
        }
        //robotPart.Attach();
        ResetCursor();
      }
    }

    private void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
