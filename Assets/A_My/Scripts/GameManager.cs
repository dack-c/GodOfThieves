using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum Ending
    {
        CatSound,
        homeInvasion,
        MissingShoes,
        MissingGloves,
        CaptureCCTV,
        Sucess
    }

    public static GameManager instance; // 싱글톤을 할당할 전역 변수

    public int timeValue;
    public bool bCatSound;
    public bool bEquipShoes;
    public bool bEquipGloves;

    public Timer timer;
    public GameObject playerObj;
    public TextMeshProUGUI pickupInteractableNoti;
    public NotiManager wearNotiManager;
    public ItemController itemController;
    public Door FriendExternalDoor;

    public Ending ending;

    public bool bEnterFriendHouse = false;
    public bool bExitFriendHouse = false;


    // 게임 시작과 동시에 싱글톤을 구성
    void Awake()
    {
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우
            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    public void StartTimer(int timeValue)
    {
        this.timeValue = timeValue;
        timer.gameObject.SetActive(true);
    }

    public void EndGame(bool bTimeout)
    {
        if(bTimeout)
        {
            ending = Ending.CaptureCCTV;
            Debug.Log("timeout ending");
        }
        else if (20 > timeValue || timeValue > 22)
        {
            ending = Ending.homeInvasion;
        }
        else if(bCatSound)
        {
            ending = Ending.CatSound;
        }
        else if(!bEquipShoes)
        {
            ending = Ending.MissingShoes;
        }
        else if(!bEquipGloves)
        {
            ending = Ending.MissingGloves;
        }
        else
        {
            ending = Ending.Sucess;
        }
        

        //실제로 엔딩씬으로 씬전환 필요
        SceneManager.LoadScene("ending_scene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
