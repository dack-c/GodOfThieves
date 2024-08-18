using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : Interactable
{
    public Transform nextDoorTransform;
    public float teleportOffset;
    public float playerSizeToMul = 1f;
    public bool bLocked = false;
    public bool bFriendDoor = false;
    public bool bHomeExternalDoor = false;

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

        if(bLocked)
        {
            GameManager.instance.wearNotiManager.StartNotiForSec("문이 잠겨있습니다.", 2f);
        }
        else
        {
            if(bFriendDoor && (20 > GameManager.instance.timeValue || GameManager.instance.timeValue > 22))
            {
                GameManager.instance.EndGame(false);
            }
            else if(bHomeExternalDoor && GameManager.instance.itemController.FindItemInSlotOrNull("고양이"))
            {
                GameManager.instance.EndGame(false);
            }
            GameManager.instance.playerObj.GetComponent<CharacterController>().enabled = false;
            nextDoorPos = nextDoorTransform.position + nextDoorTransform.forward * teleportOffset;
            GameManager.instance.playerObj.transform.position = nextDoorPos;
            GameManager.instance.playerObj.transform.localScale = originPlayerScale * playerSizeToMul;
            GameManager.instance.playerObj.GetComponent<CharacterController>().enabled = true;
        }
    }
}
