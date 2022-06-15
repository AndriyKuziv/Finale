using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFood : MonoBehaviour
{
    //public Transform o;
    public Transform[] obj = new Transform[20];
    public int count = 0; //public int maxNum = 10;

    public void setPosition(Transform objct, float x, float y){
        //Debug.Log("heh");
        objct.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    public void yeet(){
        for(int i = 0; i < obj.Length; i++){
            if(obj[i] != null)Destroy(obj[i].gameObject);
        }
        count = 0;
    }

    
}
