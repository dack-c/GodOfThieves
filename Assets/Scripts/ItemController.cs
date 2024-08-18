using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    private List<Item> wearingItems;
    private GameObject[] itemObjs;
    private int emptySlotIndex;
    private int curSlotIndex;
    private RaycastHit hit;
    private Ray ray;
    

    public GameObject itemLayoutObj;
    public TextMeshProUGUI pickupNoti;
    public float maxDistanceToGetItem = 5f;  //아이템으로부터 이 거리 이상 벗어나면 아이템 획득 불가
    // Start is called before the first frame update
    void Start()
    {
        if(itemLayoutObj == null)
        {
            Debug.LogError("itemLayoutObj가 null입니다! 할당해주세요.");
        }

        if(pickupNoti == null)
        {
            Debug.LogError("pickupNot가 null입니다! 할당해주세요.");
        }
        else
        {
            pickupNoti.gameObject.SetActive(false);
        }
        emptySlotIndex = 0;
        curSlotIndex = 0;
        itemObjs = new GameObject[itemLayoutObj.transform.childCount];
        wearingItems = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, maxDistanceToGetItem))
        {
            Item item = hit.collider.GetComponent<Item>();
            if(item && item.bGetted == false)
            {
                pickupNoti.gameObject.SetActive(true);
                pickupNoti.text = "[E] Pickup " + item.itemName;
                if(Input.GetKeyDown(KeyCode.E))  // 아이템 장착
                {
                    GetItem(item);
                }
            }
            else
            {
                pickupNoti.gameObject.SetActive(false);
            }
        }
        else
        {
            pickupNoti.gameObject.SetActive(false);
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
            Item item = itemObjs[curSlotIndex].GetComponent<Item>();
            item.Use();
            if(item.bWearItem)
            {
                item.gameObject.SetActive(false);
                getItemSlotUI(curSlotIndex).SetIcon(null);
                wearingItems.Add(item);
                itemObjs[curSlotIndex] = null;
            }

        }
    }

    void GetItem(Item item)
    {
        GameObject itemObj = item.gameObject;
        itemObj.transform.position = transform.position;
        itemObj.transform.parent = transform;
        item.SetRotationToEquip();
        item.Getted();
        itemObj.SetActive(false);

        itemObjs[emptySlotIndex] = itemObj;

        /*Image iconToSet = itemLayoutObj.transform.GetChild(emptySlotIndex).GetChild(0).gameObject.GetComponent<Image>();
        iconToSet.sprite = item.icon;*/
        getItemSlotUI(emptySlotIndex).SetIcon(item.icon);

        if(emptySlotIndex == curSlotIndex)
        {
            EquipItem(curSlotIndex);
        }

        emptySlotIndex++;
    }

    void EquipItem(int index)
    {
        // 해당 아이템 슬롯 테두리 하이라이트
        /*itemLayoutObj.transform.GetChild(curSlotIndex).GetChild(1).gameObject.SetActive(false);
        itemLayoutObj.transform.GetChild(index).GetChild(1).gameObject.SetActive(true);*/
        getItemSlotUI(curSlotIndex).SetHighlight(false);
        getItemSlotUI(index).SetHighlight(true);

        // 해당 아이템 장착
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

    public Item FindItemInSlotOrNull(string itemName)
    {
        foreach (var itemObj in itemObjs)
        {
            if(itemObj.GetComponent<Item>().itemName == itemName)
            {
                return itemObj.GetComponent<Item>();
            }
        }
        return null;
    }

    private ItemSlotUI getItemSlotUI(int index)
    {
        return itemLayoutObj.transform.GetChild(index).GetComponent<ItemSlotUI>();
    }
}
