using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
    // Atributos para cambiar de escena.
    private float timeScena;
    private string nivel;

    // El inicio se llama antes de la primera actualización del cuadro.
    void Start() {
        nivel = "Menu";
        timeScena = 7;
        StartCoroutine(Temp());
    }

    // Temporizador para cambiar de escena.
    IEnumerator Temp() {
        yield return new WaitForSeconds(timeScena);
        SceneManager.LoadScene(nivel);
    }
}