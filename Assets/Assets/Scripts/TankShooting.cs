using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TankShooting : MonoBehaviour
{
    private Animator anim;

    public GameObject projectilePrefab;
    public TilemapCollider2D smallrock; 
    public EdgeCollider2D Ammo;
    
    public Transform firePoint;         // �����, ����� ������ ����
    public float projectileSpeed = 10f; // �������� �������

    public float fireRate = 3f;       // �������� �� ���������
    private float nextFireTime = 0f;    // ��� �� ���������� �������


    public float timerDuration = 10f; // ��������� ������� � ��������
    private float timer;
    private bool isTimerActive = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Physics2D.IgnoreCollision(Ammo, smallrock);
       
        timer = fireRate;
    }
    void Update()
    {
       Debug.Log(isTimerActive);
        
        if (Input.GetMouseButtonDown(0) && !isTimerActive) // ������ ��� �������
        {
            isTimerActive = true;
            //anim.SetTrigger("Shoot");
            Shoot();            
            //nextFireTime = Time.time + fireRate;
            timer = fireRate;
            


        }
        if (isTimerActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isTimerActive = false;             
            }
        }
       // Debug.Log(timer.ToString());
    }

    void Shoot()
    {
        
        // ��������� ������ � ����� firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // ������ ��� �������
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.up * projectileSpeed;
        }

        // ������� ������ ����� ������ ��� (��� �������� ������������ �����)
        Destroy(projectile, 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
            Debug.Log("babax");
        }
        if (collision.gameObject.CompareTag("SmallRock"))
        {
            
           // Destroy(gameObject);
           // Debug.Log("babax");
        }
    }
    
}
