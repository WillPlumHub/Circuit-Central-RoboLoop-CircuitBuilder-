using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    public string sceneToLoad;

    private void OnMouseDown() {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
