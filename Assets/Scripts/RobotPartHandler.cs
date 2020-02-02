using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RobotPartHandler : MonoBehaviour,
                             IPointerDownHandler,
                             IPointerEnterHandler,
                             IPointerExitHandler
{
    public Texture2D SpyGlassCursor;
    public Texture2D GrabHandCursor;
    public Vector2 SpyGlassOffset;
    public Vector2 GrabHandOffset;

    public float MoveSpeed;

    public Vector3 InventoryLocation;
    public Vector3 AttachedLocation;

    public bool Pickupable = true;

    Vector3 destination;
    float Timer;

    // Start is called before the first frame update
    void Start()
    {
        addPhysics2DRaycaster();
        //spyglass = (Texture2D)Resources.Load("spyglass128.png");
        destination = this.transform.position;
    }

    void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Pickupable)
        {
            Debug.Log("Cursor entering: " + eventData.pointerCurrentRaycast.gameObject.name);
            Cursor.SetCursor(GrabHandCursor, GrabHandOffset, CursorMode.Auto);
        }
    }

    /**
      *
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
        if(Pickupable)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            destination = InventoryLocation;
        }
    }

    /**
      * Update is called once per frame
      * Handles animating movement of robot part into inventory.
      */
    void Update()
    {
        Vector3 selfPosition = this.transform.position;
        // Debug.Log(Time.deltaTime);
        Debug.Log("FPS: " + (Mathf.FloorToInt(60.0f/Time.deltaTime)));
        Timer += Time.deltaTime * MoveSpeed;

        if (selfPosition != destination)
        {
            this.transform.position = Vector3.MoveTowards(selfPosition, destination, Timer);
        }
    }

    /**
    * Moves the robot part to which this script is attached, to the configured 
    * position (intended for 'attaching' parts to the robot).
    */
    public void Attach()
    {
        Debug.Log("Attaching " + this.name);
        Pickupable = false;
        this.transform.position = AttachedLocation;
        destination = AttachedLocation;
    }
}
