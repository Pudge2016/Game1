using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Максимальна швидкість руху танка
    public float acceleration = 2f; // Прискорення танка
    public float deceleration = 5f; // Уповільнення танка
    public float turnSpeed = 100f; // Швидкість повороту
    private float currentSpeed = 0f; // Поточна швидкість руху
    private Rigidbody2D rb;

    private float timer = 0f;
    private bool isTimerRunning = true;
    public float CurrentSpeed => currentSpeed;
    private Animation mAnimation;

    void Start()
    {
        mAnimation = GetComponent<Animation>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

        timer += Time.deltaTime;
        //Debug.Log(currentSpeed);
        float moveInput = Input.GetAxis("Vertical"); // W (1) / S (-1)
        float turnInput = Input.GetAxis("Horizontal"); // A (-1) / D (1)

        // Прискорення або уповільнення залежно від введення
        if (moveInput != 0)
        {
            currentSpeed += moveInput * acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -moveSpeed, moveSpeed); // Обмеження швидкості
        }
        else
        {
            // Плавне зменшення швидкості, коли користувач не натискає клавіші
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += deceleration * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, 0);
            }
        }

        // Рух танка вперед або назад
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);

        // Поворот танка
        if (moveInput > 0) // Танку вперед
        {
            transform.Rotate(Vector3.forward * -turnInput * turnSpeed * Time.deltaTime);
            timer = 0;
        }
        else if (moveInput < 0) // Танку назад
        {
            transform.Rotate(Vector3.forward * turnInput * turnSpeed * Time.deltaTime);
            timer = 0;
        }
        else if (timer >= 0.2f)
        {
            transform.Rotate(Vector3.forward * -turnInput * turnSpeed * Time.deltaTime);
        }
        //Debug.Log(currentSpeed);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Перевірка, чи танк зіткнувся з об'єктом з тегом "rock"
        if (collision.gameObject.CompareTag("Rock"))
        {
            moveSpeed = 0.5f;
            //Debug.Log("Швидкість танка зменшена через зіткнення з rock!");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // Відновлення максимальної швидкості після того, як танк перестає торкатися об'єкта
        if (collision.gameObject.CompareTag("Rock"))
        {
            moveSpeed = 5f; // Відновлення максимальної швидкості
            Debug.Log("Швидкість танка відновлена після виходу з rock!");
        }
    }
}
