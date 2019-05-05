using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRandom : MonoBehaviour {
    // Esta estructura se usa en Unity para pasar posiciones y direcciones 3D alrededor.
    public Vector3[] positions;
    // Se llama a Start antes de la primera actualización de cuadros.
    void Start() {
        int randomNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomNumber];
    }
}