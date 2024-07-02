using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyLogic : MonoBehaviour
{
    public Transform player;
    public Transform block;
    public float minSpeed = 1f;
    public float maxSpeed = 5f;
    public float distanceClose = 2f;
    public float distanceMedium = 5f;
    public float distanceFar = 10f;
    public float activationRange = 15f; // Rango en el cual la lógica difusa se activa
    public float changeDirectionInterval = 2f; // Intervalo para cambiar la dirección

    private float speed;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float changeDirectionTimer;

    void Start()
    {
        initialPosition = block.position;
        targetPosition = initialPosition;
        changeDirectionTimer = changeDirectionInterval;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, block.position);

        if (distance <= activationRange)
        {
            speed = CalculateFuzzySpeed(distance);

            changeDirectionTimer -= Time.deltaTime;
            if (changeDirectionTimer <= 0)
            {
                SetNewTargetPosition();
                changeDirectionTimer = changeDirectionInterval;
            }

            MoveBlock();
        }
        else
        {
            block.position = initialPosition;
        }
    }

    float CalculateFuzzySpeed(float distance)
    {
        float close = Mathf.Max(0, Mathf.Min(1, (distanceMedium - distance) / (distanceMedium - distanceClose)));
        float medium = Mathf.Max(0, Mathf.Min((distance - distanceClose) / (distanceMedium - distanceClose), (distanceFar - distance) / (distanceFar - distanceMedium)));
        float far = Mathf.Max(0, Mathf.Min(1, (distance - distanceMedium) / (distanceFar - distanceMedium)));

        float slowSpeed = close * minSpeed;
        float mediumSpeed = medium * (minSpeed + maxSpeed) / 2;
        float fastSpeed = far * maxSpeed;

        float totalWeight = close + medium + far;
        return (slowSpeed + mediumSpeed + fastSpeed) / totalWeight;
    }

    void SetNewTargetPosition()
    {
        float offsetX = Random.Range(-5f, 5f);
        float offsetY = Random.Range(0f, 5f);
        float offsetZ = Random.Range(-5f, 5f);

        targetPosition = new Vector3(
            Mathf.Clamp(initialPosition.x + offsetX, initialPosition.x - 3, initialPosition.x + 3),
            Mathf.Clamp(initialPosition.y + offsetY, initialPosition.y, initialPosition.y + 3),
            Mathf.Clamp(initialPosition.z + offsetZ, initialPosition.z - 3, initialPosition.z + 3)
        );
    }

    void MoveBlock()
    {
        block.position = Vector3.Lerp(block.position, targetPosition, speed * Time.deltaTime);
    }
}

