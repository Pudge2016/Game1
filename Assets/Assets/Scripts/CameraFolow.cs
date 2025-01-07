using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{

    public Transform tank; // Посилання на трансформ танка
    public Vector3 offset; // Відстань між камерою та танком
    public float smoothSpeed = 0.125f; // Швидкість згладжування руху камери
    public float fixedZ = -10f; // Фіксоване значення Z-координати

    void LateUpdate()
    {
        // Обчислюємо нову позицію для камери з урахуванням відстані (offset)
        Vector3 desiredPosition = tank.position + offset;
        // Згладжуємо рух камери
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Заморожуємо Z-координату
        smoothedPosition.z = fixedZ;

        // Оновлюємо позицію камери
        transform.position = smoothedPosition;

        // Камера дивиться на танк
        transform.LookAt(tank);
    }
}
