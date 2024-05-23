using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : UIScript
{

    private int WeaponSelecter = 0;
    private int NumberofWeapons = 4;
    WeaponArrow weaponArrow;
    WeaponAxe weaponAxe;
    WeaponKunai weaponKunai;
    WeaponSpark weaponSpark;


    void Start(){
        weaponArrow = this.gameObject.GetComponent<WeaponArrow>();
        weaponAxe = this.gameObject.GetComponent<WeaponAxe>();
        weaponKunai = this.gameObject.GetComponent<WeaponKunai>();
        weaponSpark= this.gameObject.GetComponent<WeaponSpark>();
    }


   void Update(){
    if (Input.GetKeyDown(KeyCode.Q)){
        WeaponSelecter++;
        if (WeaponSelecter == NumberofWeapons){
            WeaponSelecter = 0;
        }
    }

    if (Input.GetKeyDown(KeyCode.E)){
        WeaponSelecter += -1;
        if (WeaponSelecter < 0){
            WeaponSelecter = NumberofWeapons-1;
        }
    }

    if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (WeaponSelecter)
            {   
                case 0:
                    weaponArrow.ShootArrow();
                    break;
                case 1:
                    weaponAxe.ThrowAxe();
                    break;
                case 2:
                    weaponKunai.ShootKunai();
                    break;
                case 3:
                    weaponSpark.ShootSpark();
                    break;
                default:
                    WeaponSelecter = 0;
                    break;
            }
            
           
        }
   }
}
