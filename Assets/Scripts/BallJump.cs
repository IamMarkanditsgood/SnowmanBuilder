using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; // ������ ������
    [SerializeField] private float jumpForceMultiplier = 5f; // ���� ������
    [SerializeField] private float spawnDelay = 0.1f; // �������� ����� �������
    [SerializeField] private float ceilingCheckDistance = 0.1f; // ���������� ��� �������� �������
    [SerializeField] private LayerMask ceilingLayer; // ����, �� ������� ��������� �������

    [SerializeField] private GameObject _loseView;
    private Rigidbody2D rb;
    private float ballHeight;

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentRecord", 0);
        rb = GetComponent<Rigidbody2D>();
        ballHeight = GetComponent<SpriteRenderer>().bounds.size.y; // ���������� ������ ������
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0) // ��� ��� ������� �� �����
        {
            if (!IsCeilingAbove()) // ���������, ���� �� ������� ������
            {
                PlayerPrefs.SetInt("CurrentRecord", PlayerPrefs.GetInt("CurrentRecord") + 1);
                StartCoroutine(JumpWithDelay());
            }
        }
    }

    private IEnumerator JumpWithDelay()
    {
        float jumpForce = ballHeight * jumpForceMultiplier;
        Vector2 prevPos = transform.position;

        // ��������� ������� �����
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // ��� ����� �������, ����� ������� ����� ����� ���������
        yield return new WaitForSeconds(spawnDelay);

        // ������� ����� �����
        SpawnBall(prevPos);
    }

    private void SpawnBall(Vector3 position)
    {
        Instantiate(ballPrefab, position, Quaternion.identity);
    }

    private bool IsCeilingAbove()
    {
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.up;
        float distance = ballHeight / 2 + ceilingCheckDistance; // ��������� �� ��������� ���������� ��� �������

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, ceilingLayer);
        return hit.collider != null; // ���� ���� ��������� ������, ������ ������� ������
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Floor"))
        {
            PlayerPrefs.SetInt("FirstAchieve", 1);
            _loseView.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
