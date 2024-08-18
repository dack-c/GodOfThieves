using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactName;

    public bool bStopInteract = false;

    public abstract void Interact();
}
