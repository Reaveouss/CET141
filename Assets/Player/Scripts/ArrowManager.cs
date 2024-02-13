using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] float rawDamage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Release(float thrust)
    {
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
        Destroy(gameObject, 8f);
    }


    private void OnCollisionEnter(Collision rigidbody)
    {
        if (rigidbody.gameObject.tag == "Enemysd")
        {
            Debug.Log("Arrow Hit");
            rigidbody.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Arrow Miss");
        }
        //Destroy(gameObject);
    }

}
