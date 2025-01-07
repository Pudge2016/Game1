using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotating : MonoBehaviour
{
    public Transform Tower; // ���� ������� ��'��� ����� � ���������
    public Camera mainCamera; // ������� ������ (��� ���������� ������� ����)
    public float rotationSpeed = 200f; // �������� �������� ����� (������� �� �������)

    // ��� �����������, ���� ����� �� "��������" ������ (���������� �� �����������)
    public float rotationOffset = -90f;

    private void Update()
    {
        RotateTurretToMouse();
    }

    private void RotateTurretToMouse()
    {
        if (mainCamera == null)
        {
            Debug.LogError("�� ������ ������� ������! ������� ��������� �� ������� ������ � ���������.");
            return;
        }

        // ��������� ������� ���� � ���
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // ���������� �������� �� ����
        Vector3 directionToMouse = mousePosition - Tower.position;

        // ��������� ���� � �������, � ���� ����������� � �������
        float targetAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // ������ ��� �����������, ���� �������
        targetAngle += rotationOffset;

        // �������� �������� ��� �����
        float currentAngle = Tower.eulerAngles.z;

        // ˳���� ��������� ����� �� ���� ����
        float angle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

        // ������������ ��������� �����
        Tower.rotation = Quaternion.Euler(0, 0, angle);
    }
}
