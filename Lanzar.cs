using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzar : MonoBehaviour
{ 
    public Rigidbody pelota;
    public float velocidadInicial;
// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody instanciaPelota = Instantiate(pelota, transform.position, transform.rotation);
            Vector3 fuerza = new Vector3(0, 10, 40);
            instanciaPelota.AddForce(fuerza * velocidadInicial);
            Destroy(instanciaPelota.gameObject, 3);
        }
    }
    }
