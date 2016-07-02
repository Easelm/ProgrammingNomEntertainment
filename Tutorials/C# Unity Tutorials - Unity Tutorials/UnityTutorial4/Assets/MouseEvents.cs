using UnityEngine;
using UnityEngine.EventSystems;

public class MouseEvents : MonoBehaviour
{
    private EventTrigger rawImageEventTrigger;

    // Use this for initialization
    void Start()
    {
        rawImageEventTrigger = GetComponent<EventTrigger>();
        if (rawImageEventTrigger != null)
        {
            rawImageEventTrigger.triggers[0].callback.AddListener(delegate { Debug.Log("PointerEnter"); });
            rawImageEventTrigger.triggers[1].callback.AddListener(delegate { Debug.Log("PointerExit"); });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        //Debug.Log("You have entered the sprite");
    }

    void OnMouseOver()
    {
        //Debug.Log("You are over the sprite");
    }

    void OnMouseExit()
    {
        //Debug.Log("You have exited the sprite");
    }
}
