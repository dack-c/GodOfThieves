using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start2 : MonoBehaviour
{
    
    void Start()
    {

    }
    // Start is called before the first frame update
    public void OnButtonClicked()
    {
        SceneManager.LoadScene("scene1");  
    }

    public int Button()
    {
        SceneManager.LoadScene("scene1");  
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
