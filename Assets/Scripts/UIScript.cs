using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class UIScript : MonoBehaviour
{

    public EnemySpawner EnemySpawner;
    private AudioManager Audiomanager;

    public int PlayerHP = 100;
    public int PlayerExp = 0 ; 
    public int EXPperLVL = 10;
    public int LVL = 0; 

    public int Score = 0;
    public Text ScoreText;
    public Slider HpBar;
    public Slider EXPbar;
    
    public Text LVLText;

    public Tilemap currentTilemap;
    public TilemapManager tilemapManager;


    void Start(){
        InvokeRepeating("score",1,1);
        EnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        Audiomanager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        PlayerHP = 100;
        PlayerExp = 0;
        LVL = 0;
        Score = 0;

        if (tilemapManager == null)
        {
            tilemapManager = GameObject.FindObjectOfType<TilemapManager>();
        }
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
        Audiomanager.Play("PowerUp");
        if (PlayerExp >= EXPperLVL){
            PlayerExp = 0 ;
            LVL++;
            LVLText.text = ("LVL : " + LVL.ToString());

            int tilemapIndex = LVL % tilemapManager.tilemaps.Length;
            currentTilemap = tilemapManager.tilemaps[tilemapIndex];
            tilemapManager.ActivateTilemap(currentTilemap);
        }
    }


}
