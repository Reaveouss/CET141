using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] float maxHitPoints = 100f;
    // Start is called before the first frame update
    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;

        Debug.Log("OUCH: " + hitPoints.ToString());

        if (hitPoints <=0)
        {
            Debug.Log("TODO: GAME OVER - YOU DIED");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints > maxHitPoints)
        {
            hitPoints = maxHitPoints;
        }
    }

    void Heal(float rawHealing)
    {
        hitPoints += rawHealing;
        Debug.Log("Healed" + hitPoints.ToString());
    }
}
