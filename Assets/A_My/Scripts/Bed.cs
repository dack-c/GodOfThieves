using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bed : Interactable
{
    public GameObject timeSelectionObj;
    public GameObject directionaLight;

    public TMP_InputField timeInputField;
    public override void Interact()
    {
        Debug.Log("interact 호출");
        //GameManager.instance.itemController.bAcitiveNumKey = false;
        timeSelectionObj.SetActive(true);
        //timeInputField = timeInputObj.GetComponent<InputField>(); 
    }

    public void OnClickSubmitBtn()
    {
        string inputValue = timeInputField.text;
        int timeValue;
        try
        {
            timeValue = int.Parse(inputValue);
        }
        catch
        {
            return;
        }

        if(timeValue < 0 || timeValue > 23)
        {
            return;
        }

        int sunAngle = -90 - 15 * timeValue;
        directionaLight.transform.eulerAngles = new Vector3(sunAngle, -30, 0);

        //GameManager.instance.itemController.bAcitiveNumKey = true;
        timeSelectionObj.SetActive(false);
        GameManager.instance.StartTimer(timeValue);
        bStopInteract = true;
    }

    public void OnClickCancelBtn()
    {
        timeSelectionObj.SetActive(false);
    }
}
