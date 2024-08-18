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
        else
        {
            agent.SetDestination(fishTransform.position);
        }

        if(bGetted && !bPlayingSound)
        {
            bPlayingSound = true;
            audioSource.Play();
        }
    }


    public override void Use()
    {
        return;
    }
}
