using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : Item
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
        wearNotiManager.StartNotiForSec("장갑?을 장착했습니다.", notiDuration);
    }
}
