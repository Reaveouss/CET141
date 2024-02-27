using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    float hitPoints;
    [SerializeField] float maxHitPoints = 100f;

    public Slider healthSlider;
    // Start is called before the first frame update

    private void Start()
    {
        hitPoints = maxHitPoints;
    }
    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        SetHealthSlider();

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
        SetHealthSlider();
        Debug.Log("Healed" + hitPoints.ToString());
    }

    private void SetHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = NormalisedHitPoints();
        }
    }

    float NormalisedHitPoints()
    {
        return hitPoints / maxHitPoints;
    }
}
