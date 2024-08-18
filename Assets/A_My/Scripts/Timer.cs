using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text timeText;
    private bool bGameEnd = false;

    public float remainTime = 300f;
    void Awake()
    {
        timeText = GetComponent<TMP_Text>();
        gameObject.SetActive(false);
    }

    // 다시 게임오브젝트가 활성화되면 실행
    void Update()
    {
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
