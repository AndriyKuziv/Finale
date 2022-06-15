using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    private float x, y;
    public int minx = -13, miny = -7, maxx = 13, maxy = 6;

    private GameManager gm;
    private IFoo food;

    public Food(IFoo inter){
        food = inter;
    }

    private void Start() {
        gm = FindObjectOfType<GameManager>();

        // Debug.Log("min x: " + bounds.min.x);
        // Debug.Log("min y: " + bounds.min.y);
        // Debug.Log("max x: " + bounds.max.x);
        // Debug.Log("max y: " + bounds.max.y);
    }


    public void newOne(){
        x = Random.Range(minx, maxx);
        y = Random.Range(miny, maxy);

        food.create(x,y);
    }

    public void destroyAll(){
        food.yeet();
    }

    public void effectFromFood(){
        food.affect();
    }
}
