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
    public bool bFriendExternalDoor = false;
    public bool bHomeExternalDoor = false;
    public bool bFriendInternalDoor = false;

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
            if(bFriendExternalDoor && (20 > GameManager.instance.timeValue || GameManager.instance.timeValue > 22))  // 진구 있을 때 친구집 들어갈 경우(오후8~오후10시 가 아닌 경우)
            {
                GameManager.instance.EndGame(false);
            }
            else if(bHomeExternalDoor && GameManager.instance.itemController.FindItemInSlotOrNull("고양이"))  // 고양이 데리고, 내 집 들어갔을 경우
            {
                GameManager.instance.EndGame(false);
            }
            else if(bFriendExternalDoor)  // 친구집 안으로 들어갔을 때
            {
                GameManager.instance.bEnterFriendHouse = true;
            }
            else if(bFriendInternalDoor)  // 친구집 밖으로 나갔을 때
            {
                GameManager.instance.bExitFriendHouse = true;
                if(GameManager.instance.bCatSound)
                {
                    Invoke("EndGemeGo", 5f);
                }
            }
            GameManager.instance.playerObj.GetComponent<CharacterController>().enabled = false;
            nextDoorPos = nextDoorTransform.position + nextDoorTransform.forward * teleportOffset;
            GameManager.instance.playerObj.transform.position = nextDoorPos;
            GameManager.instance.playerObj.transform.localScale = originPlayerScale * playerSizeToMul;
            GameManager.instance.playerObj.GetComponent<CharacterController>().enabled = true;
        }
    }

    void EndGemeGo()
    {
        GameManager.instance.EndGame(false);
    }
}
