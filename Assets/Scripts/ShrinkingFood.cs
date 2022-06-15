using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingFood : MonoBehaviour
{
    private BadApple ba;

    private void Start() {
        ba = (BadApple)FindObjectOfType(typeof(BadApple));
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            ba.affect();
        }
        Destroy(this.gameObject);
    }
}
