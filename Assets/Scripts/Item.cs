using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public Sprite icon;
    public Vector3 equipRotation;
    public string itemName;

    public bool bGetted;
    public bool bWearItem = false;
    private void Start()
    {
        bGetted = false;
        if(equipRotation == null)
        {
            equipRotation = transform.localEulerAngles;
        }
    }

    public void SetRotationToEquip()  // 아이템 장착 시 아이템의 회전값 설정
    {
        transform.localEulerAngles = equipRotation;
    }

    public abstract void Use();
    public virtual void Getted()
    {
        bGetted = true;
    }

}
