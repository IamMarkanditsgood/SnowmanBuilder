using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRoof : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // �������� ��������
    [SerializeField] private float resetPositionX = 10f; // ��� ������ �������� ������
    [SerializeField] private float thresholdX = -10f; // ��� ������ �������� � ����������� �����

    private void Update()
    {
        // ������� ������ �����
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ���� ������ ���� �� �������, ��������� ��� �����
        if (transform.position.x <= thresholdX)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = resetPositionX;
        transform.position = newPosition;
    }
}
