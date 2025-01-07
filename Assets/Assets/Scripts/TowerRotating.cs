using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotating : MonoBehaviour
{
    public Transform Tower; // Сюди додайте об'єкт башти в інспекторі
    public Camera mainCamera; // Основна камера (для визначення позиції миші)
    public float rotationSpeed = 200f; // Швидкість повороту башти (градуси на секунду)

    // Кут компенсації, якщо башта не "дивиться" вперед (налаштуйте за необхідності)
    public float rotationOffset = -90f;

    private void Update()
    {
        RotateTurretToMouse();
    }

    private void RotateTurretToMouse()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Не задана основна камера! Додайте посилання на головну камеру в інспекторі.");
            return;
        }

        // Отримання позиції миші у світі
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Розрахунок напрямку до миші
        Vector3 directionToMouse = mousePosition - Tower.position;

        // Отримання кута в радіанах, а потім конвертація в градуси
        float targetAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // Додаємо кут компенсації, якщо потрібно
        targetAngle += rotationOffset;

        // Отримуємо поточний кут башти
        float currentAngle = Tower.eulerAngles.z;

        // Лінійно повертаємо башту до кута миші
        float angle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

        // Встановлюємо обертання башти
        Tower.rotation = Quaternion.Euler(0, 0, angle);
    }
}
