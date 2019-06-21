using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoAleatorio : MonoBehaviour {

    [SerializeField] float velocidadMovimiento = 5;
    [SerializeField] float tiempoCambioDireccion = 3;
    CharacterController miCC;

    void Awake()
    {
        miCC = GetComponent<CharacterController>();
    }

    private void Start()
    {
        InvokeRepeating("CambiarDireccionMovimiento", tiempoCambioDireccion, tiempoCambioDireccion);
    }

    private void Update()
    {
        miCC.SimpleMove(this.transform.forward * velocidadMovimiento);
    }

    void CambiarDireccionMovimiento()
    {
        float rotacionAleatoria = Random.Range(0, 360);
        Vector3 rotacionAAplicar = new Vector3(0, rotacionAleatoria, 0);
        this.transform.Rotate(rotacionAAplicar);
    }

}
