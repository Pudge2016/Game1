using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TankShooting : MonoBehaviour
{

    public GameObject projectilePrefab;
    public TilemapCollider2D smallrock; 
    public EdgeCollider2D Ammo;
    
    public Transform firePoint;         // �����, ����� ������ ����
    public float projectileSpeed = 10f; // �������� �������

    public float fireRate = 0.5f;       // �������� �� ���������
    private float nextFireTime = 0f;    // ��� �� ���������� �������

    private void Start()
    {
        Physics2D.IgnoreCollision(Ammo, smallrock);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) // ������ ��� �������
        {
            Shoot();
            nextFireTime = Time.deltaTime + fireRate;
            
        }
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
        Destroy(projectile, 5f);
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
