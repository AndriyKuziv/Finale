using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyFood : MonoBehaviour
{
    private Bomb bomb;

    private void Start() {
        bomb = (Bomb)FindObjectOfType(typeof(Bomb)); 
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            bomb.affect();
            //Debug.Log("hu");
            }
        else if(other.transform.tag != "Player" || other.tag != "Player" || other.gameObject.tag != "Player"){
            Debug.Log("huh");
            Destroy(this.gameObject);
        }

    }
}
