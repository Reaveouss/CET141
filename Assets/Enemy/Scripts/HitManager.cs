using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 25;
    // Start is called before the first frame update
    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        if (hitPoints <= 0)
        {
            Invoke("SelfTerminate", 0f);
        }
    }

    // Update is called once per frame
    void SelfTerminate()
    {
        Destroy(gameObject);
    }
        
 
}
