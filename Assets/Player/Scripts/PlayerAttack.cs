using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Transform cameraTransform;
    float range = 100f;
    LayerMask layerMask;

    [SerializeField]
    float rawDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer));
    }


    // Update is called once per frame
    void Update()
    {
        if (!MenuController.IsGamePaused)
        {
            FireWeapon();
        }
    }
    void FireWeapon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cameraTransform = Camera.main.transform;
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, range, layerMask))
            {
                if (raycastHit.transform != null)
                {
                    raycastHit.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    Debug.Log("NO RAYCAST");
                }
            }
        }
    }
}
