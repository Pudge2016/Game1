using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ����������� �������� ���� �����
    public float acceleration = 2f; // ����������� �����
    public float deceleration = 5f; // ����������� �����
    public float turnSpeed = 100f; // �������� ��������
    private float currentSpeed = 0f; // ������� �������� ����
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

        // ����������� ��� ����������� ������� �� ��������
        if (moveInput != 0)
        {
            currentSpeed += moveInput * acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -moveSpeed, moveSpeed); // ��������� ��������
        }
        else
        {
            // ������ ��������� ��������, ���� ���������� �� ������� ������
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

        // ��� ����� ������ ��� �����
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);

        // ������� �����
        if (moveInput > 0) // ����� ������
        {
            transform.Rotate(Vector3.forward * -turnInput * turnSpeed * Time.deltaTime);
            timer = 0;
        }
        else if (moveInput < 0) // ����� �����
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
        // ��������, �� ���� �������� � ��'����� � ����� "rock"
        if (collision.gameObject.CompareTag("Rock"))
        {
            moveSpeed = 0.5f;
            //Debug.Log("�������� ����� �������� ����� �������� � rock!");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // ³��������� ����������� �������� ���� ����, �� ���� ������� ��������� ��'����
        if (collision.gameObject.CompareTag("Rock"))
        {
            moveSpeed = 5f; // ³��������� ����������� ��������
            Debug.Log("�������� ����� ��������� ���� ������ � rock!");
        }
    }
}
