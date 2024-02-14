using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Sprite icon;

    [SerializeField] string itemName;
    [TextArea(4, 16)]
    [SerializeField] string description;

    [SerializeField] float weight = 0;
    [SerializeField] int quantity = 1;
    [SerializeField] int maxStackableQuantity = 1; //For bundles of items 

    [SerializeField] bool isStorable = false; //false means item is used when picked up
    [SerializeField] bool isConsumable = true; //true means item is destroyed/ reduced by 1 when used
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

    private void OnTriggerEnter(Collider collider)
    {
        if (isPickupOnCollision)
        {
            if (collider.tag == "Player")
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Picked up " + transform.name);
        if (isStorable)
        {
            Store();
        }
        else
        {
            Use();
        }
    }

    void Store()
    {
        Debug.Log("Storing " + transform.name);
        //TODO inventory system
        Destroy(gameObject);
    }

    void Use()
    {
        if (isConsumable)
        {
            quantity--;

            if (quantity <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
