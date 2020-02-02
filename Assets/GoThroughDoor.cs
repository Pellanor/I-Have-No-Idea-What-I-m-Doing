using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoThroughDoor : MonoBehaviour,
                             IPointerDownHandler,
                             IPointerEnterHandler,
                             IPointerExitHandler
{
    public Texture2D EnterCursorSprite;
    public Vector2 EnterCursorOffset;

    public Texture2D NoEntryCursorSprite;
    public Vector2 NoEntryCursorOffset;

    public string NextSceneName;

    public bool Enterable = true;

    // Start is called before the first frame update
    void Start()
    {
        //addPhysics2DRaycaster();
    }

    /**
      * Attaches a 2D Raycaster component to the camera, so pointer handling works
      */
    void addPhysics2DRaycaster()
    {
        // Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        // if (physicsRaycaster == null)
        // {
        //     Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        // }
    }

    /**
      * Handle mouse moving onto the robot part.
      * This sets the cursor.
      */
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Cursor entering: " + eventData.pointerCurrentRaycast.gameObject.name);
        if(Enterable)
        {
            Cursor.SetCursor(EnterCursorSprite, EnterCursorOffset, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(NoEntryCursorSprite, NoEntryCursorOffset, CursorMode.Auto);
        }
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
        if(Enterable)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            ResetCursor();

            // Change Scene
            SceneManager.LoadScene(NextSceneName);
        }
    }

    private void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
