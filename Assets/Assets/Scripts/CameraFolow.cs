using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{

    public Transform tank; // ��������� �� ��������� �����
    public Vector3 offset; // ³������ �� ������� �� ������
    public float smoothSpeed = 0.125f; // �������� ������������ ���� ������
    public float fixedZ = -10f; // Գ������� �������� Z-����������

    void LateUpdate()
    {
        // ���������� ���� ������� ��� ������ � ����������� ������ (offset)
        Vector3 desiredPosition = tank.position + offset;
        // ��������� ��� ������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ���������� Z-����������
        smoothedPosition.z = fixedZ;

        // ��������� ������� ������
        transform.position = smoothedPosition;

        // ������ �������� �� ����
        transform.LookAt(tank);
    }
}
