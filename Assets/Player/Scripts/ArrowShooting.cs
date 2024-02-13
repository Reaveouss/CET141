using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    Transform cameraTransform;
    float Thrust = 2000f;
    public GameObject arrowPrefab;
    public Transform spawnPoint;
    GameObject arrowInstance;
    bool arrowHeld = false;
    bool arrowActive = false;

    float arrowRespawnTarget = 0.2f;
    float arrowPullbackTarget = 1f;
    float arrowRespawnTimer = 0f;
    float arrowPullbackTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        SpawnArrow();
        //arrowInstance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //arrowInstance.GetComponent<Rigidbody>().useGravity = false;
        //ARROW.constraints = RigidbodyConstraints.FreezePosition;
        //GetComponent<Rigidbody>().AddForce(transform.forward * Thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("BUTTON DOWN");
            //arrowInstance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //arrowInstance.GetComponent<Rigidbody>().AddForce(transform.forward * Thrust);
            arrowHeld = true;
        }

        if (Input.GetButtonUp("Fire1") && arrowHeld)
        {
            Debug.Log("BUTTON UP");
            //arrowInstance.GetComponent<Rigidbody>().useGravity = true;
            arrowInstance.transform.SetParent(null);
            arrowInstance.GetComponent<ArrowManager>().Release(Thrust);
            arrowHeld = false;
            arrowActive = false;
            arrowPullbackTimer = 0f;
        }

        if (!arrowActive)
        {
            arrowRespawnTimer += Time.deltaTime;
            if (arrowRespawnTimer >= arrowRespawnTarget)
            {
                arrowRespawnTimer = 0;
                SpawnArrow();
            }
        }



        if (arrowHeld)
        {
            arrowPullbackTimer += Time.deltaTime;
            if(arrowPullbackTimer >= arrowPullbackTarget)
            {
                arrowPullbackTimer = arrowPullbackTarget;
                //Reach max
            }
            //code to adjust thrust, 0-2000
        }

    }

    void SpawnArrow()
    {
        Debug.Log("Spawn Arrow");
        arrowInstance = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
        arrowInstance.transform.parent = gameObject.transform;
        arrowActive = true;
    }


    //private void OnCollisionEnter(Collision rigidbody)
    //{
    //    if (rigidbody.gameObject.tag == "EnemyObject")
    //    {
    //        rigidbody.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
    //    }
    //    else
    //    {
    //        Debug.Log("Miss");
    //    }
    //    Destroy(rigidbody.gameObject);
    //}
}
