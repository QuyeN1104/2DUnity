using System.Collections;
using UnityEngine;

public class FallingFlat : MonoBehaviour
{
    // Thời gian delay trước khi platform rơi
    public float timeDelay;

    // Component Rigidbody2D của platform
    private Rigidbody2D body;

    // Khởi tạo và lấy component Rigidbody2D
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Khi có va chạm xảy ra
    void OnCollisionEnter2D(Collision2D target)
    {
        // Kiểm tra nếu đối tượng va chạm có tag là "player"
        if (target.gameObject.tag == "Player")
        {
            // Bắt đầu coroutine Falling()
            StartCoroutine(Falling());
        }
    }

    // Coroutine xử lý việc platform rơi sau một khoảng thời gian delay
    IEnumerator Falling()
    {
        // Chờ một khoảng thời gian delay
        yield return new WaitForSeconds(timeDelay);

        // Đổi kiểu body thành Dynamic để cho phép rơi tự do
        body.bodyType = RigidbodyType2D.Dynamic;

        // Đóng băng góc quay để tránh platform quay khi rơi
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
