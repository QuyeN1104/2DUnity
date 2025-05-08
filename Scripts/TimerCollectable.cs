using UnityEngine;

public class TimerCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<TimerScript>().time += 10;
            AudioManager.Instance.Collect();
        }

    }
}
