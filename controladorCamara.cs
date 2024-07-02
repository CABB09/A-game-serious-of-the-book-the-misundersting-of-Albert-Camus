using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorCamara : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 compensacion;
    // Start is called before the first frame update
    void Start()
    {
        compensacion = transform.position - jugador.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = jugador.transform.position + compensacion;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
