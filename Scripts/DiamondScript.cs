using TMPro;
using UnityEngine;
using UnityEngine.Video;


public class DiamondScript : MonoBehaviour
{
    static public int score = 0;
    public TextMeshProUGUI txtScore;
    private void Start()
    {
        /*if (DoorScript.Instance != null)
        {
            DoorScript.Instance.CollectablesCount++;
        }*/
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.Collect();
            Destroy(gameObject);
            score++;
            txtScore.text = "Score: " + score;

        }
    }
}
