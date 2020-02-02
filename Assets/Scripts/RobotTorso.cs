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

    /**
      * Handle mouse moving onto the robot part.
      * This sets the cursor.
      */
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Cursor entering: " + eventData.pointerCurrentRaycast.gameObject.name);
        // if(Enterable)
        // {
        //     Cursor.SetCursor(EnterCursorSprite, EnterCursorOffset, CursorMode.Auto);
        // }
        // else
        // {
        //     Cursor.SetCursor(NoEntryCursorSprite, NoEntryCursorOffset, CursorMode.Auto);
        // }
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
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);

        GameObject selected = this.Inventory.GetCurrentlySelected();
        RobotPartHandler robotPart = selected.GetComponent<RobotPartHandler>();

        if(selected != null && robotPart != null)
        {
            robotPart.Attach();
            ResetCursor();
        } else {
          Debug.Log("DIALOG: You cannot do this.");
        }
    }

    private void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
