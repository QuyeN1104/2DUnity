using UnityEngine;
using System.Collections;

public class OctoEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float attackInterval = 0.5f; // Khoảng cách giữa các lần tấn công

    // Cache transform để tối ưu hơn khi gọi nhiều lần
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        if (bullet == null)
        {
            Debug.LogWarning("Bullet prefab has not been assigned in the Inspector!");
        }
        StartCoroutine(AttackCoroutine());
    }

    private void Update()
    {
        Move();
        Debug.Log(speed);
    }

    private void Move()
    {
        Vector2 newPosition = _transform.position;
        newPosition.x += speed * Time.deltaTime;
        _transform.position = newPosition;
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (bullet != null)
            {
                Instantiate(bullet, _transform.position - new Vector3(0, -0.5f, 0), _transform.rotation);
            }
            yield return new WaitForSeconds(attackInterval);
        }
    }

    // Khi đi qua vật có tag "Left" hoặc "Right" (collider cần đánh dấu IsTrigger = true)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "left")
        {
            speed = -speed;
            Vector2 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
        }
        if (collision.gameObject.tag == "right")
        {
            speed = -speed;
            Vector2 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
        }

        else
        {
            Debug.Log(collision.gameObject);
        }
    }
}
