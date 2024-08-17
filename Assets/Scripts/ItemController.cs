using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private GameObject[] itemObjs;
    private int emptySlotIndex;
    private int curSlotIndex;
    private RaycastHit hit;
    private Ray ray;
    

    public GameObject itemLayoutObj;
    // Start is called before the first frame update
    void Start()
    {
        if(itemLayoutObj == null)
        {
            Debug.LogError("itemLayoutObj가 null입니다! 할당해주세요.");
        }
        emptySlotIndex = 0;
        curSlotIndex = 0;
        itemObjs = new GameObject[itemLayoutObj.transform.childCount];
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit))
        {
            Item item = hit.collider.GetComponent<Item>();
            if (item && Input.GetKeyDown(KeyCode.E))  // 아이템 장착
            {
                GetItem(item);
            }

            if(item)
            {
                Debug.Log("아이템 장착가능.");
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown((KeyCode)(i + 49)))  // 숫자키 1~9 입력 감지
            {
                EquipItem(i);
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && itemObjs[curSlotIndex] != null)  // 아이템 사용
        {
            itemObjs[curSlotIndex].GetComponent<Item>().Use();
        }
    }

    void GetItem(Item item)
    {
        GameObject itemObj = item.gameObject;
        itemObj.transform.position = transform.position;
        itemObj.transform.parent = transform;
        item.SetRotationToEquip();
        itemObj.SetActive(false);

        itemObjs[emptySlotIndex] = itemObj;

        Image iconToSet = itemLayoutObj.transform.GetChild(emptySlotIndex).GetChild(0).gameObject.GetComponent<Image>();
        iconToSet.sprite = item.icon;

        if(emptySlotIndex == curSlotIndex)
        {
            EquipItem(curSlotIndex);
        }

        emptySlotIndex++;
    }

    void EquipItem(int index)
    {
        if (itemObjs[curSlotIndex] != null)
        {
            itemObjs[curSlotIndex].SetActive(false);
        }
        if(itemObjs[index] != null)
        {
            itemObjs[index].SetActive(true);
        }
        curSlotIndex = index;
    }
}
