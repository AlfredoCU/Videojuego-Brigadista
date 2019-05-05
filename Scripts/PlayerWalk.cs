using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerWalk : MonoBehaviour {
    // Atributos para movimiento y audio del player.
    public int playerSpeed;
    public AudioSource fuente;
    // Atributos para texto y valores.
    public Text winOverText;
    public Text countText;
    public Text pointText;
    public Text timeText;
    private int count;
    private int point;
    private float time;
    private bool timeRun;
    // Atributos para cambiar de escena.
    private float timeScena;
    private string nivel;
    // Fuego.
    public GameObject fuego;
    // Control.
    public float speed = 3.5f;
    private float gravity = 10f;
    private CharacterController controller;

    // El inicio se llama antes de la primera actualización del cuadro.
    void Start() {
        count = 0;
        point = 0;
        time = 120f;
        timeRun = true;
        winOverText.text = "";
        SetCountText();
        SetPointText();
        SetTimeText();
        fuego.SetActive(false);
        controller = GetComponent<CharacterController>();
    }

    // La actualización se llama una vez por trama.
    void Update() {
        SetTimeText();
        // Devuelve verdadero mientras buttonNamese mantiene presionado (Fire1 es para mouse).
        if (Input.GetButton("Fire1")) {
            // Transforma la posicion, con la camara hacia adelante, velocidad del jugador y tiempo.
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
        else {
            // Audio de pasos.
            fuente.Play();
        }
        PlayerMovement();
    }

    // Obtener los objetos.
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Puntos")) {
            Destroy(other.gameObject);
            count++;
            point = count * 10;
            SetCountText();
            SetPointText();
        }
    }

    // Objetos encontrados.
    private void SetCountText() {
        countText.text = "Encontrados: " + count.ToString();
        if(count >= 21) {
            winOverText.text = "GANASTE";
            timeRun = false;
            nivel = "Menu";
            timeScena = 5;
            StartCoroutine(Temp());
        }
    }

    // Obtener los puntos.
    public void SetPointText() {
        pointText.text = "Puntos: " + point.ToString();
    }

    // Tiempo.
    public void SetTimeText() {
        if (timeRun) {
            time -= Time.deltaTime;
            timeText.text = "Tiempo: " + time.ToString("f0");
            if (time <= 0) {
                timeRun = false;
                timeText.text = "Tiempo: 0";
                fuego.SetActive(true);
                winOverText.text = "PERDISTE";
                nivel = "Menu";
                timeScena = 10;
                StartCoroutine(Temp());
            }
        }
    }

    // Temporizador para cambiar de escena.
    IEnumerator Temp() {
        yield return new WaitForSeconds(timeScena);
        SceneManager.LoadScene(nivel);
    }

    // Movimiento del control.
    private void PlayerMovement() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
        fuente.Play();
    }
}