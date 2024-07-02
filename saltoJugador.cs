using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltoJugador : MonoBehaviour
{
    private Rigidbody rbSalto;
    private bool enSuelo = false;
    // Start is called before the first frame update
    void Start()
    {
        rbSalto = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rbSalto.AddForce(Vector3.up * 5, ForceMode.Impulse);
            enSuelo = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}
