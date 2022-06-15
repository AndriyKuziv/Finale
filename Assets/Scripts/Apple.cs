using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : TFood, IFoo
{
    public int numberOfScores = 1;

    private Player player;
    private Transform apple;

    public Apple(Transform a){
        apple = a;
    }

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    public void create(float x, float y){
        obj[count] = Instantiate(apple);
        setPosition(obj[count].transform, x, y);
        count++;
        Debug.Log("apple: " + count);
    }

    public void affect(){
        
        for(int i = 0; i < numberOfScores; i++) {
            player.Grow();
            i++;
        }
        
    }
}
