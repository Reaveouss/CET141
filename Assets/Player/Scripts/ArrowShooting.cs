using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    Transform cameraTransform;
    float Thrust = 10f;
    [SerializeField] float rawDamage = 10f;
    Rigidbody Arrow;
    Rigidbody ARROW;
    public GameObject Arrows;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Arrow = GetComponentInChildren<Collider>().attachedRigidbody;
        ARROW = FindAnyObjectByType<Rigidbody>();
        ARROW.constraints = RigidbodyConstraints.FreezePosition;
        GetComponent<Rigidbody>().AddForce(transform.forward * Thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Arrows, spawnPoint.position, spawnPoint.rotation);
            ARROW.constraints = RigidbodyConstraints.None;
            Arrow.AddForce(transform.forward * Thrust);

        }

    }
    private void OnCollisionEnter(Collision rigidbody)
    {
        if (rigidbody.gameObject.tag == "EnemyObject")
        {
            rigidbody.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            Debug.Log("Miss");
        }
        Destroy(rigidbody.gameObject);
    }
}
