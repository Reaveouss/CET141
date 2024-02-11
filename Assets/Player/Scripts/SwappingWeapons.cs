using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Swappingweapons : MonoBehaviour
{
    [SerializeField] int WeaponID;
    [SerializeField] string WeaponName;
    public GameObject GUN;
    public GameObject BowAndArrow;
    // Start is called before the first frame update
    void Start()
    {
        WeaponID = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAttack playerAttack = FindAnyObjectByType<PlayerAttack>();
        ArrowShooting arrowShooting = FindAnyObjectByType<ArrowShooting>(); 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponID = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponID = 2;
        }

        switch (WeaponID)
        {
            case 1:
                GUN.gameObject.SetActive(true);
                BowAndArrow.gameObject.SetActive(false);
                playerAttack.enabled = true;
                arrowShooting.enabled = false;
                break;
            case 2:
                GUN.gameObject.SetActive(false);
                BowAndArrow.gameObject.SetActive(true);
                playerAttack.enabled = false;
                arrowShooting.enabled = true;
                break;
        }
        
    }
}
