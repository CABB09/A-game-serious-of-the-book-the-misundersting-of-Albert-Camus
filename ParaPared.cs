using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ParaPared : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider otro)
    {
        if (otro.gameObject.CompareTag("bonus2"))
        {
            Destroy(otro.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
