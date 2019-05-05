using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    // Busca y te manda a esa escena.
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    // Salir del juego.
    public void QuitApp() {
        Application.Quit();
    }
}