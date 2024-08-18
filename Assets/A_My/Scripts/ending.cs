using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending : MonoBehaviour
{
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;
    public Sprite img5;
    public Sprite img6;
    Image thisImg;

    int end_br=2;
    // Start is called before the first frame update
    void Start()
    {
        thisImg=GetComponent<Image>();

        switch(end_br){
            case 1:
            thisImg.sprite = img1;
            break;
            case 2:
            thisImg.sprite = img2;
            break;
            case 3:
            thisImg.sprite = img3;
            break;
            case 4:
            thisImg.sprite = img4;
            break;
            case 5:
            thisImg.sprite = img5;
            break;
            case 6:
            thisImg.sprite = img6;
            break;
            default:
            break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
