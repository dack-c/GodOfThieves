using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Transform nextDoorTransform;
    public float teleportOffset;
    public float playerSizeToMul = 1f;

    private Vector3 nextDoorPos;
    private Vector3 originPlayerScale;

    // Start is called before the first frame update
    void Start()
    {
        originPlayerScale = GameManager.instance.playerObj.transform.localScale;
    }
    public override void Interact()
    {
        Debug.Log("문 Interact");
        GameManager.instance.playerObj.GetComponent<CharacterController>().enabled = false;
        nextDoorPos = nextDoorTransform.position + nextDoorTransform.forward * teleportOffset;
        GameManager.instance.playerObj.transform.position = nextDoorPos;
        GameManager.instance.playerObj.transform.localScale = originPlayerScale * playerSizeToMul;
        GameManager.instance.playerObj.GetComponent<CharacterController>().enabled = true;
    }
}
