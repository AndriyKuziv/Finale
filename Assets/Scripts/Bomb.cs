using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : TFood, IFoo
{
    public int maxNum = 10;

    private Player player;
    private Transform bomb;

    public Bomb(Transform b){
        bomb = b;
    }


    private void Start() {
        player = FindObjectOfType<Player>();
    }

    public void create(float x, float y){
        if(count < maxNum){
            obj[count] = Instantiate(bomb);
            setPosition(obj[count], x, y);
            count++;
            Debug.Log("Bomb: " + count);
        }
    }

    public void affect(){
        player.Die(0);
    }
}
