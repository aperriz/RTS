using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

public class Background : NetworkBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Background Left Click");
            eventData.pressEventCamera.gameObject.GetComponent<SelectionController>().ClearSelection();
        }
        else if(eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Background Right Click");
            foreach(Selectable s in eventData.enterEventCamera.gameObject.GetComponent<SelectionController>().selectedObjects)
            {
                if(s.GetType() == typeof(Unit))
                {
                    s.Move(eventData.enterEventCamera.ScreenToWorldPoint(eventData.pressPosition));
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
