using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float speed = 2f;
    private float direction;
    private GameObject boss;

    void Awake()
    {
        boss = GameObject.Find("Boss");
        if (boss != null)
        {
            direction = Mathf.Sign(boss.transform.localScale.x);
            Vector2 scale = transform.localScale;
            scale.x = direction;
            transform.localScale = scale;
        }
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += direction * speed * Time.deltaTime;
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "bound")
        {
            Destroy(gameObject);
        }
    }
}
