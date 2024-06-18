using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionController : NetworkBehaviour
{
    [SerializeField]
    private List<Controllable> selectedObjects = new List<Controllable>();
    public LayerMask clickable;
    new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("Click");
        if (context.started)
        {
            //Debug.Log(Mouse.current.position.ReadValue());

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            
            if(!Physics.Raycast(ray, out hit, Mathf.Infinity, clickable)) { Debug.Log("No hit"); return; }

            Debug.Log("Hit");
            Controllable target;

            if (hit.collider.TryGetComponent<Controllable>(out target))
            {
                target.Select();
                Debug.Log("Selected");
            }
        }
    }

    public void OverwriteSelect(Controllable target)
    {
        selectedObjects.Clear();
        selectedObjects.Add(target);
    }

    public void OverwriteSelect(Controllable[] targets)
    {
        selectedObjects.Clear();
        foreach (Controllable target in targets)
        {
            selectedObjects.Add(target);
        }
    }

    public void AdditiveSelect(Controllable target)
    {
        selectedObjects.Add(target);
    }

    public void AdditiveSelect(Controllable[] targets) 
    {    
        foreach (Controllable target in targets)
        {
            selectedObjects.Add(target);
        }
    }

    public void Deselect(Controllable target)
    {
        if (selectedObjects.Contains(target)) { selectedObjects.Remove(target); }
    }

    public void Deselect(Controllable[] targets)
    {
        if(targets.Count() == selectedObjects.Count)
        {
            selectedObjects.Clear();
        }
        else
        {
            foreach (Controllable target in targets)
            {
                selectedObjects.Remove(target);
            }
        }
    }
}
