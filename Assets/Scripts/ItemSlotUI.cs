using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 테두리 하이라이트 비활성화
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
