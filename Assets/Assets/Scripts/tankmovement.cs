using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ���� �����
    public float turnSpeed = 100f;
    private KeyCode lastKeyPressed;
    private Vector3 lastPosition;

    private float timer = 0f;
    private bool isTimerRunning = true;

    private Rigidbody2D rb;// �������� �������� �����
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastKeyPressed = KeyCode.W;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastKeyPressed = KeyCode.S;
        }
        // ��� ������-�����
        float moveInput = Input.GetAxis("Vertical"); // W (1) / S (-1)
        transform.Translate(Vector3.up * moveInput * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        float turnInput = Input.GetAxis("Horizontal"); // A (-1) / D (1)
        if (Input.GetKey(KeyCode.W))
        {
            timer = 0;
            transform.Rotate(Vector3.forward * -turnInput * turnSpeed * Time.deltaTime);
            
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            timer = 0;
            transform.Rotate(Vector3.forward * +turnInput * turnSpeed * Time.deltaTime);
            
        }
        
        else if (timer >= 0.2f) 
        {
            transform.Rotate(Vector3.forward * -turnInput * turnSpeed * Time.deltaTime); 
        }

        // ��������, �� ���� �� ��������
        if (rb.velocity.magnitude == 0) // ���� �������� ����� ������� ����
        {
           // Debug.Log("���� �� ��������");
        }


    }
    private bool HasPositionChanged()
    {
        float threshold = 0.01f; // ���� ���� (���������, 1 ��)
        if (Vector3.Distance(transform.position, lastPosition) > threshold)
        {
            lastPosition = transform.position;
            return true;
        }
        return false;
    }
   
}