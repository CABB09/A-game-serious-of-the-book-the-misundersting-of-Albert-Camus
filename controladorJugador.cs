using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controladorJugador : MonoBehaviour
{
    public float velocidad;
    private AudioSource audioSource;
    private Rigidbody rb;
    private int score = 0;  // Variable para la puntuación
    public Text scoreText;  // Referencia al objeto de texto UI
    public int totalBonus;  // Número total de bonus en la escena
    public GameObject restartText;  // Texto UI que muestra la opción de reinicio
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        audioSource.enabled = false;
        UpdateScoreText();
        restartText.SetActive(false);
    }

    private void FixedUpdate()
    {
        float deltaY = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        float deltaX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        transform.Translate(deltaX, 0, deltaY);
    }
    private void OnTriggerEnter(Collider otro)
    {
        if (otro.gameObject.CompareTag("bonus"))
        {
            Destroy(otro.gameObject);
            audioSource.enabled = true;
            StartCoroutine(DesactivarAudioSource());
            audioSource.Play();
            score++;  // Incrementa la puntuación
            UpdateScoreText();
            if (score == totalBonus)
            {
                EndGame();
            }
        }
    }

    private IEnumerator DesactivarAudioSource()
    {
        // Espera un breve período de tiempo antes de desactivar el AudioSource
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.enabled = false;
    }
    // Update is called once per frame
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    private void EndGame()
    {
        restartText.SetActive(true);
    }
    void Update()
    {
        if (restartText.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

