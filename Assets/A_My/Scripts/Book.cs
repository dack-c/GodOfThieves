using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Interactable
{
    public GameObject bookUiObj;

    private void Start()
    {
        bookUiObj.SetActive(false);
    }

    public override void Interact()
    {
        bookUiObj.SetActive(true);
    }

    public void OnClickBookCloseBtn()
    {
        bookUiObj.SetActive(false);
    }
}
