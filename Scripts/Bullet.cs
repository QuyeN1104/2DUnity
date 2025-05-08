using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject boom;
    private void Start()
    {

    }
    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= Time.deltaTime * speed;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.Die();
            }
            Destroy(gameObject);
            Destroy(Instantiate(boom, transform.position, this.transform.rotation), 1f);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            AudioManager.Instance.Bullet();
            Destroy(Instantiate(boom, transform.position, this.transform.rotation), 1);
            Destroy(gameObject);
        }
    }
}
