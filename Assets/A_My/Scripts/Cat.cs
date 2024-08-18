using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : Item
{
    public float fishDetectRadius;

    private AudioSource audioSource;
    private NavMeshAgent agent;
    private bool bFindFish = false;
    private Transform fishTransform;
    private bool bPlayingSound = false;
    private GameObject soundGameObj;

    //RaycastHit rayHit = new RaycastHit();

    //public Transform testTarget;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out rayHit))
            {
                Debug.Log("마우스로 목적지 지정");
                //agent.destination = rayHit.point;
                agent.SetDestination(rayHit.point);
            }
        }*/

        if (!bFindFish)
        {
            //agent.SetDestination(testTarget.position);
            Collider[] colliders = Physics.OverlapSphere(transform.position, fishDetectRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "fish")  // fish를 발견하면
                {
                    bFindFish = true;
                    fishTransform = collider.transform;
                    break;
                }
            }
        }
        else if(!bGetted)
        {
            agent.SetDestination(fishTransform.position);
        }

        /*if(bGetted && !bPlayingSound)
        {
            agent.isStopped = true;
            agent.enabled = false;
            agent.transform.position = transform.parent.position;
            SetRotationToEquip();

            // cat이 비활성화(아이템 교체)되도 소리 계속 날 수 있도록
            soundGameObj = new GameObject("CatSound", typeof(AudioSource));
            soundGameObj.GetComponent<AudioSource>().clip = audioSource.clip;
            soundGameObj.GetComponent<AudioSource>().loop = audioSource.loop;
            soundGameObj.GetComponent<AudioSource>().playOnAwake = audioSource.playOnAwake;
            soundGameObj.transform.position = transform.position;
            soundGameObj.transform.parent = transform.parent.parent;

            bPlayingSound = true;
            soundGameObj.GetComponent<AudioSource>().Play();
        }*/
    }

    public override void Getted()
    {
        agent.isStopped = true;
        agent.enabled = false;

        // cat이 비활성화(아이템 교체)되도 소리 계속 날 수 있도록
        soundGameObj = new GameObject("CatSound", typeof(AudioSource));
        soundGameObj.GetComponent<AudioSource>().clip = audioSource.clip;
        soundGameObj.GetComponent<AudioSource>().loop = audioSource.loop;
        soundGameObj.GetComponent<AudioSource>().playOnAwake = audioSource.playOnAwake;
        soundGameObj.transform.position = transform.position;
        soundGameObj.transform.parent = transform.parent.parent;

        bPlayingSound = true;
        GameManager.instance.bCatSound = true;
        soundGameObj.GetComponent<AudioSource>().Play();

        bGetted = true;
    }

    public void StopSound()
    {
        if(soundGameObj && bPlayingSound)
        {
            soundGameObj.GetComponent<AudioSource>().Stop();
            GameManager.instance.bCatSound = false;
        }
    }

    public override void Use()
    {
        return;
    }
}
