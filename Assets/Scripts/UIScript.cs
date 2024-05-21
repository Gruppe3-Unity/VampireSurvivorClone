using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public int PlayerHP = 100;
    public int PlayerExp = 0 ; 
    public int LVL = 0; 
    public Text ScoreText;
    public Slider HpBar;

    void Start(){


    }
    
    void Update(){

        
    }

    
    public void PlayerHit(int Damagetaken){
        PlayerHP = PlayerHP - Damagetaken;
        
        HpBar.value = (float)PlayerHP/100;
        if (PlayerHP >= 0){

        }
       
    }
    public void GiveExp (int Exp){
        PlayerExp += Exp;
        ScoreText.text = ("Score :" + PlayerExp.ToString());
        
    }


}
