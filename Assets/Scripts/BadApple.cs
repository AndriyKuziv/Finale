using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadApple : TFood, IFoo
{
    private Player player;
    private Transform bApple;

    public BadApple(Transform b){
        bApple = b;
    }


    private void Start() {
        player = FindObjectOfType<Player>();
    }

    public void create(float x, float y){
        obj[count] = Instantiate(bApple);
        setPosition(obj[count], x, y);
        count++;
        Debug.Log("BadApple: " + count);
    }

    public void affect(){
        if(player._segments.Count > 2){
            Destroy(player._segments[player._segments.Count - 1].gameObject);
            player._segments.RemoveAt(player._segments.Count - 1);
        }
    }
}
