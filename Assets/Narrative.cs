using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Narrative : MonoBehaviour,
                             IPointerDownHandler,
                             IPointerEnterHandler,
                             IPointerExitHandler
{
    public Texture2D SpyGlassCursor;
    public Vector2 SpyGlassOffset;

    public bool Viewable = true;

    public string ConversationKey;

    public GameObject FacePopup;

    // Start is called before the first frame update
    void Start()
    {
        addPhysics2DRaycaster();
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
        if(Viewable)
        {
            Debug.Log("Cursor entering: " + eventData.pointerCurrentRaycast.gameObject.name);
            Cursor.SetCursor(SpyGlassCursor, SpyGlassOffset, CursorMode.Auto);
        }
    }

    /**
      * Handles mouse moving off the robot part.
      * This resets the cursor.
      */
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Cursor exiting: " + eventData);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    /** 
      * Handles clicking on this robot piece.
      * If it can be collected into inventory, it sets inventory as destination.
      */
    public void OnPointerDown(PointerEventData eventData)
    {
        if(Viewable)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            PopupConversation pc = FacePopup.GetComponent<PopupConversation>();
            pc.LoadConversation(ConversationKey);
        }
    }
}
