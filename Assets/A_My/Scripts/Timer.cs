using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text timeText;
    private bool bGameEnd = false;
    public GameObject fade;
    public GameObject npc1;
    public GameObject npc2;

    public float remainTime = 300f;
    int a;

    public bool bStratTimer;

    void Awake()
    {
        a=0;
        timeText = GetComponent<TMP_Text>();
        gameObject.SetActive(false);
    }
    void faded()
    {
        fade.gameObject.SetActive(false);
    }
    // 다시 게임오브젝트가 활성화되면 실행

    private void Start()
    {
        bStratTimer = true;
    }

    void Update()
    {
        if(a==0)
        {
            a=1;
            fade.gameObject.SetActive(true);
            npc1.gameObject.SetActive(false);
            npc2.gameObject.SetActive(false);
            Invoke("faded",1f);

        }
        if (!bGameEnd)
        {
            if (remainTime > 0)
            {
                remainTime -= Time.deltaTime;
                timeText.text = "CCTV가 다시 켜질때까지 남은 시간(초): " + Mathf.Ceil(remainTime).ToString();
            }
            else
            {
                bGameEnd = true;
                GameManager.instance.EndGame(true);
            }
        }   
    }
}
