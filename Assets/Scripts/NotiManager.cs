using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotiManager : MonoBehaviour
{
    private TextMeshProUGUI noti;
    // Start is called before the first frame update
    void Start()
    {
        noti = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void StartNoti(string msg)
    {
        gameObject.SetActive(true);
        noti.text = msg;
    }

    public void StartNotiForSec(string msg, float second)
    {
        gameObject.SetActive(true);
        StartCoroutine(StartNotiForSecCo(msg, second));
    }

    private IEnumerator StartNotiForSecCo(string msg, float second)
    {
        noti.text = msg;
        yield return new WaitForSeconds(second);
        gameObject.SetActive(false);
    }
}
