using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talk2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dd;
    public TMP_Text tl;
    public TMP_Text tl2;
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Player")
        {
            tl.text = "진구가 이민간대서, 내일 8시에\n우리집에서 송별회를 하기로 했어!";
            tl2.text = "이슬이";
            dd.gameObject.SetActive(true);
            Invoke("off", 2f);
        }
    }
    void off()
    {
        dd.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
