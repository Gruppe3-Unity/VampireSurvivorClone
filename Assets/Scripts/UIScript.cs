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
    public Text LVLPopUp;
    public Text StartPopUp;

    public GameObject EndGame;

    private IEnumerator Coroutinelvlup;
    private IEnumerator CoroutineStartUP;

    public Tilemap currentTilemap;
    public TilemapManager tilemapManager;


    void Start(){
        InvokeRepeating("score",1,1);
        EnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>(); 
        Audiomanager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        Time.timeScale = 1;
        PlayerHP = 100;
        PlayerExp = 0;
        LVL = 0;
        Score = 0;
        Audiomanager.Play("Fight[0]");
        if (tilemapManager == null)
        {
            tilemapManager = GameObject.FindObjectOfType<TilemapManager>();
        }
           StartPopUp.gameObject.SetActive(true);
            CoroutineStartUP = StartPoptext(2.0f);
            StartCoroutine(CoroutineStartUP);


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
        Audiomanager.Play("PlayerHit");
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
            EXPperLVL += 10;
            LVLText.text = ("LVL : " + LVL.ToString());
            if (LVL == 11){
                EndGame.gameObject.SetActive(true);
                Time.timeScale = 0;
                
            }
            else{
            LVLPopUp.gameObject.SetActive(true);
            Coroutinelvlup = lvlUPText(2.0f);
            StartCoroutine(Coroutinelvlup);

            }
            int tilemapIndex = LVL % tilemapManager.tilemaps.Length;
            currentTilemap = tilemapManager.tilemaps[tilemapIndex];
            tilemapManager.ActivateTilemap(currentTilemap);
            try{
            Audiomanager.Stop("Fight["+(tilemapIndex-1)+"]");
            }catch{Audiomanager.StopAll();}
            Audiomanager.Play("Fight["+tilemapIndex+"]");
            
        }
    }

    private IEnumerator lvlUPText(float waitTime){
        yield return new WaitForSeconds(waitTime);
        LVLPopUp.gameObject.SetActive(false);
        
    }

    private IEnumerator StartPoptext(float waitTime){
        yield return new WaitForSeconds(waitTime);
        StartPopUp.gameObject.SetActive(false);
        
    }

}
