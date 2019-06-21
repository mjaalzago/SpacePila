using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modopatrulla : MonoBehaviour {

    [Header("Patrulla")]
    [SerializeField] Transform[] _puntosPatrulla;
    [SerializeField] float minDistanciaConseguir = 1;
    [SerializeField] float velocidadMovimiento = 3;

    CharacterController miCC;
    int _currentPatrolPointIndex;


    Vector3 CurrentPatrolPoint
    {
        get
        {
            return _puntosPatrulla[_currentPatrolPointIndex].position;
        }
    }

    private void Awake()
    {
        miCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {

        this.transform.LookAt(CurrentPatrolPoint);
        miCC.SimpleMove(this.transform.forward * velocidadMovimiento);

        float distance = Vector3.Distance(transform.position, CurrentPatrolPoint);

        Debug.Log("Distancia: " + distance);
        if (distance < minDistanciaConseguir)
        {
            _currentPatrolPointIndex = (_currentPatrolPointIndex + 1) % _puntosPatrulla.Length;
        }

    }
}
