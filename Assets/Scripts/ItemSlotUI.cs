using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 테두리 하이라이트 및 아이템 아이콘 비활성화
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).GetComponent<Image>().sprite = null;
    }

    public void SetHighlight(bool bActive)
    {
        if(bActive)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void SetIcon(Sprite sprite)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
    }
}
