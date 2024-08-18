using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : Item
{
    public ItemController itemController;
    public NotiManager catSleepNoti;
    public float notiDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        if(itemController == null)
        {
            itemController = GameObject.FindWithTag("itemHolder").GetComponent<ItemController>();
        }
    }

    public override void Use()
    {
        Cat cat = itemController.FindItemInSlotOrNull("고양이") as Cat;
        if (cat)
        {
            cat.StopSound();
            catSleepNoti.StartNotiForSec("고양이가 잠들었습니다!", notiDuration);
        }
    }
}
