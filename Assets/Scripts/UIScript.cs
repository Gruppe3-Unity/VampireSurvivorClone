using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class UIScript : MonoBehaviour
{

     public EnemySpawner EnemySpawner;

    public int PlayerHP = 100;
    public int PlayerExp = 0 ; 
    public int EXPperLVL = 10;
    public int LVL = 0; 

    public int Score = 0;
    public Text ScoreText;
    public Slider HpBar;
    public Slider EXPbar;
    
    public Text LVLText;


    void Start(){
        InvokeRepeating("score",1,1);
        EnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        PlayerHP = 100;
        PlayerExp = 0;
        LVL = 0;
        Score = 0;

    }
    
    void Update(){

        
    }

    private void score(){
        Score++;
        ScoreText.text = ("Score : " + Score.ToString());
        if ( Score % 10 == 0){
            EnemySpawner.NumberOfEnemy += 1;
        }
    }


    public void PlayerHit(int Damagetaken){
        PlayerHP = PlayerHP - Damagetaken;
        
        HpBar.value = (float)PlayerHP/100;
        if (PlayerHP <= 0){
            SceneManager.LoadScene("Start Screen");

        }
       
    }
    public void GiveExp (int Exp){
        PlayerExp += Exp;
        EXPbar.value = (float)PlayerExp/EXPperLVL;
        if (PlayerExp >= EXPperLVL){
            PlayerExp = 0 ;
            LVL++;
            LVLText.text = ("LVL : " + LVL.ToString());
        }
    }


}
