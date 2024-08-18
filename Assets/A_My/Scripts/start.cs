using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    
    void Start()
    {
        
    }
    // Start is called before the first frame update
    public GameObject diary;
    public GameObject buttons;
    public void OnButtonClicked()
    {
        diary.gameObject.SetActive(true);
        buttons.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
