using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Item
{
    public GameObject lightObj;

    private void Start()
    {
        if(lightObj == null)
        {
            lightObj = transform.GetChild(0).gameObject;
        }
        lightObj.SetActive(false);
    }

    public override void Use()
    {
        if(lightObj.activeSelf)
        {
            lightObj.SetActive(false);
        }
        else
        {
            lightObj.SetActive(true);
        }
    }
}
