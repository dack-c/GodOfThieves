using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperClip : Item
{
    private RaycastHit hit;
    private Ray ray;

    public override void Use()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, GameManager.instance.itemController.maxDistanceToGetItem))
        {
            Door door = hit.collider.GetComponent<Door>();
            if(door.bLocked)
            {
                door.bLocked = false;
                GameManager.instance.wearNotiManager.StartNotiForSec("문의 잠금이 해제되었습니다!", 2f);
            }
        }
    }
}
