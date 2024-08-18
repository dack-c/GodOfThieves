using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class talk : MonoBehaviour
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
            tl.text = "도라에몽은 유독 어디 밑에\n들어가있는걸 좋아하더라";
            tl2.text = "진구";
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
