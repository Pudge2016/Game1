using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{

    public GameObject projectilePrefab; // ������ �������
    public Transform firePoint;         // �����, ����� ������ ����
    public float projectileSpeed = 10f; // �������� �������

    public float fireRate = 0.5f;       // �������� �� ���������
    private float nextFireTime = 0f;    // ��� �� ���������� �������

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) // ������ ��� �������
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            
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
    }
}
