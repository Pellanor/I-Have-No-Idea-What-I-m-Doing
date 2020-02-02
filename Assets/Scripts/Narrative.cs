using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Narrative : MonoBehaviour,
                             IPointerDownHandler,
                             IPointerUpHandler,
                             IPointerEnterHandler,
                             IPointerExitHandler
{
    Texture2D SpyGlassCursor;
    Vector2 SpyGlassOffset = new Vector2(5, 5);

    public bool Readable = true;

    public string ConversationKey;

    public PopupConversation popup;

    [System.Serializable]
    public struct ConversationState {
        public GameState.State state;
        public string conversationKey;
    }
    public ConversationState[] conversations;

    // Start is called before the first frame update
    void Start()
    {
        addPhysics2DRaycaster();
        this.SpyGlassCursor = (Texture2D)Resources.Load("MouseCursors/spyglass32");
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
        if(Readable)
        {
            Debug.Log("Cursor entering: " + eventData.pointerCurrentRaycast.gameObject.name);
            //Cursor.SetCursor(SpyGlassCursor, SpyGlassOffset, CursorMode.Auto);
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
        if(Readable)
        {
            if(eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
                Cursor.SetCursor(SpyGlassCursor, SpyGlassOffset, CursorMode.Auto);
            }
        }
    }

    private string GetConversation() {
        foreach (ConversationState conv in conversations) {
            if (GameState.IsState(conv.state)) {
                return conv.conversationKey;
            }
        }
        return ConversationKey;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(Readable)
        {
            if(eventData.button == PointerEventData.InputButton.Right)
            {
                popup.LoadConversation(GetConversation());
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
    }
}
