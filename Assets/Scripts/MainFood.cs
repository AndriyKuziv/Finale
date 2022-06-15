using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFood : MonoBehaviour
{
    private Bounds bounds;
    private GameManager gm; 
    private Apple apple;
    
    private float x, y;

    private void Start() {
        apple = (Apple)FindObjectOfType(typeof(Apple));
        gm = FindObjectOfType<GameManager>();
    }

    public void randomizePosition(){
        bounds = gm.retBounds();

        x = Random.Range(bounds.min.x, bounds.max.x);
        y = Random.Range(bounds.min.y, bounds.max.y);
        // Debug.Log("x:" + x);
        // Debug.Log("y:" + y);
    }

    public void setPos(Transform f){
        randomizePosition();
        f.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }


    public void OnTriggerEnter2D(Collider2D other) {
        setPos(this.transform);
        if(other.tag == "Player") {
            //Debug.Log("wait wat");
            apple.affect();
        }
        else if(other.transform.tag != "Player" || other.tag != "Player" || other.gameObject.tag != "Player") {
            Debug.Log("another teleportation");
            setPos(this.transform);
        }
        else{
            
        }

    }

}
