using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            transform.position = temp;
        }
    }
}
