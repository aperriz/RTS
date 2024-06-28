using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using Unity.Services.Matchmaker.Models;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Selectable : NetworkBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    public ulong _ownerId;
    public SelectionController _owner;
    public bool ownedByEveryone;

    public void SetOwnerObject()
    {
        //if (!IsOwner) { return; }

        if (!ownedByEveryone)
        {
            NetworkManager.Singleton.ConnectedClients[_ownerId].PlayerObject.TryGetComponent(out _owner);
            _owner.ownedUnits.Add(this);
        }
        else
        {
            GameManager.globalUnits.Add(this);
        }
    }

    virtual public void Select(SelectionController player)
    {
       player.OverwriteSelect(this);
    }

    virtual public void OwnerSelect()
    {
        _owner.OverwriteSelect(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");

        ulong clickId = eventData.enterEventCamera.gameObject.GetComponent<NetworkObject>().OwnerClientId;
        SelectionController clicker = NetworkManager.Singleton.ConnectedClients[clickId].PlayerObject.GetComponent<SelectionController>();

        if (ownedByEveryone)
        {
            //If public resource
            Select(clicker);
        }
        else
        {
            if (_owner == null)
            {
                SetOwnerObject();
            }

            if (clickId == _ownerId)
            {
                //Select unit if owner id matches
                OwnerSelect();
            }
            else
            {
                //Later show stats in GUI
                clicker.ClearSelection();
            }
        }

    }
    private void OnMouseDown()
    {
        Debug.Log("Mouse down");
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }


}
