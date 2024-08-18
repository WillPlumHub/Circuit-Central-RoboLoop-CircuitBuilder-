using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OptionButton : MonoBehaviour {

    public pauseMenu pauseMenu;

    void OnMouseOver() {
        Debug.Log("HGTHT");
        pauseMenu.Menu.GetComponent<Animator>().SetTrigger("OptionHover");
    }

    void OnMouseExit() {
        pauseMenu.Menu.GetComponent<Animator>().SetTrigger("EmptyHover");
    }
}