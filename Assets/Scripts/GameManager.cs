using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class GameManager : MonoBehaviour
{
    public int interval = 5;
    public int secondStage = 15;
    public Text scoreLine;
    public GameObject GameOverMenu;
    public GameObject PauseMenu;
    public BoxCollider2D gridArea;

    public Transform BApplePrefab;
    public Transform BombPrefab;
    public Transform apple;


    private Menu gOm;
    private Menu pM;
    private Food bomb;
    private Food bApple;
    private Food apl;


    private Player player;
    private int score, next;
    
    private void Start() {
        gOm = new Menu(GameOverMenu);
        pM = new Menu(PauseMenu);

        apl = new Food(new Apple(apple));
        bomb = new Food(new Bomb(BombPrefab));
        bApple = new Food(new BadApple(BApplePrefab));

        player = FindObjectOfType<Player>();

        gOm.switchMenu();
        apl.newOne();

        // Debug.Log("min x: " + gridArea.bounds.min.x);
        // Debug.Log("min y: " + gridArea.bounds.min.y);
        // Debug.Log("max x: " + gridArea.bounds.max.x);
        // Debug.Log("max y: " + gridArea.bounds.max.y);
    }

    public Bounds retBounds(){
        return gridArea.bounds;
    }

    private bool check = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && !gOm.isActive()){
            pM.switchMenu();
        }
    }

    private void FixedUpdate() {
        score = player.Score(); 
        if(score == next){
            RandomObject();
            next = next + interval;
        }
        switch(secondStage){
            case 0:
            break;
            default:
                if(score >= secondStage && !check){
                    interval *= 2;
                    check = true;
                    }
            break;
        }

        scoreLine.text = "Score: " + score;
    }

    public void ResetAll(){
        gOm.switchMenu();

        apl.destroyAll();
        bomb.destroyAll();
        bApple.destroyAll();

        apl.newOne();


        if(check) {
            check = false;
            interval /= 2;
        }
        next = interval;
    }
    

    public void gameOver(){
        gOm.switchMenu();
    }
   
    private void RandomObject(){
        int r = Random.Range(0,3);
        switch(r){
            case 0:
            bomb.newOne();
            break;
            
            case 1:
            bomb.newOne();
            break;

            case 2:
            bApple.newOne();
            break;
        }
    }
   
}
