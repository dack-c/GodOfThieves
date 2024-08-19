using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoes : Item
{
    public NotiManager wearNotiManager;
    public float notiDuration;
    // Start is called before the first frame update
    void Start()
    {
        bWearItem = true;
    }

    public override void Use()
    {
        wearNotiManager.StartNotiForSec("덧신을 장착했습니다.", notiDuration);
        if(GameManager.instance.timer.bStratTimer == false || (GameManager.instance.timer.bStratTimer && GameManager.instance.bEnterFriendHouse == false))
        {
            GameManager.instance.bEquipShoes = true;
        }
    }
}
