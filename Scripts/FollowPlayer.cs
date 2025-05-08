using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // tính toán offset
        Vector2 offset = new Vector2(player.position.x * 0.1f, 0f);

        GetComponent<Renderer>().material.mainTextureOffset = offset;

        // move bg
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        transform.position = temp;
    }
}
