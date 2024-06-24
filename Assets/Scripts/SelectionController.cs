using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class SelectionController : NetworkBehaviour
{
    [SerializeField]
    private List<Selectable> selectedObjects = new();

    public void OverwriteSelect(Selectable target)
    {
        selectedObjects.Clear();
        selectedObjects.Add(target);
    }

    public void OverwriteSelect(Selectable[] targets)
    {
        selectedObjects.Clear();
        foreach (Selectable target in targets)
        {
            selectedObjects.Add(target);
        }
    }

    public void AdditiveSelect(Selectable target)
    {
        selectedObjects.Add(target);
    }

    public void AdditiveSelect(Selectable[] targets)
    {
        foreach (Selectable target in targets)
        {
            selectedObjects.Add(target);
        }
    }

    public void Deselect(Selectable target)
    {
        if (selectedObjects.Contains(target)) { selectedObjects.Remove(target); }
    }

    public void Deselect(Selectable[] targets)
    {
        if (targets.Count() == selectedObjects.Count)
        {
            selectedObjects.Clear();
        }
        else
        {
            foreach (Selectable target in targets)
            {
                selectedObjects.Remove(target);
            }
        }
    }
}
