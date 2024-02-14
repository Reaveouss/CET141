using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    [SerializeField] float rawDamage = 2.5f;
    [SerializeField] float delayTimer = 1f;
    [SerializeField] Transform playerTransform;
    float tick;
    Transform particleTransform;
    bool attackReady = true;

    // Start is called before the first frame update
    void Start()
    {
        tick = delayTimer;
        particleTransform = gameObject.transform.Find("Gas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool IsReadyToAttack()
    {
        if (tick < delayTimer)
        {
            tick += Time.deltaTime;
            return false;
        }
        return true;
    }

    private void OnTriggerStay(Collider collision)
    {
        attackReady = IsReadyToAttack();
        Debug.Log("OnTriggerEnter Called");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player detected");
            if (attackReady)
            {
                tick = 0f;
                Debug.Log("Poisoned");
                playerTransform.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
