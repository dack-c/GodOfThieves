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

        GameManager.Ending endingVer = GameManager.instance.ending;
        switch(endingVer)
        {
            case GameManager.Ending.CaptureCCTV:
                thisImg.sprite = img1;
                break;
            case GameManager.Ending.MissingGloves:
                thisImg.sprite = img2;
                break;
            case GameManager.Ending.MissingShoes:
                thisImg.sprite = img3;
                break;
            case GameManager.Ending.homeInvasion:
                thisImg.sprite = img4;
                break;
            case GameManager.Ending.CatSound:
                thisImg.sprite = img5;
                break;
            case GameManager.Ending.Sucess:
                thisImg.sprite = img6;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
