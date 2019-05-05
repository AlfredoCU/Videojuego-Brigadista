using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnAudio : MonoBehaviour {
    // Atributos de audio, boton y evento click.
    public AudioSource fuente;
    public AudioClip clip;

    // El inicio se llama antes de la primera actualización del cuadro.
    void Start() {
        fuente.clip = clip;
    }

    // Reproducir audio.
    public void Reproducir() {
        fuente.Play();
    }
}