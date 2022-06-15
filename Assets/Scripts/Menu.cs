using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : IMenu
{
    GameObject menu;
    public Menu(GameObject m){
        menu = m;
    }

    public bool isActive(){
        if(menu.activeSelf) return true;
        return false;
    }

    public void switchMenu(){
        if(menu.activeSelf){
            menu.SetActive(false);
            Time.timeScale = 1;
        }
        else {
            menu.SetActive(true);
            Time.timeScale = 0;
            }
    }
}
