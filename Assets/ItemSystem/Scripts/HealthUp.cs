using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] string itemName;
    [TextArea(4, 16)]
    [SerializeField] string Description;

    [SerializeField] bool isPickupOnCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        if (isPickupOnCollision)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
