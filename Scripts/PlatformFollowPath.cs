using UnityEngine;

public class PlatformFollowPath : MonoBehaviour
{
    public PathDefinition path;
    public float MoveSpeed = 1f;
    private Transform _TargetPoint;

    void Start()
    {
        if (path == null) return;
        _TargetPoint = path.GetPointAt(0);
    }

    void Update()
    {
        if (path == null) return;

        // Di chuyển platform đến điểm mục tiêu
        transform.position = Vector2.MoveTowards(transform.position, _TargetPoint.position, MoveSpeed * Time.deltaTime);

        // Tính khoảng cách giữa platform và điểm mục tiêu
        float distance = Vector2.Distance(transform.position, _TargetPoint.position);

        // Nếu platform đến gần điểm mục tiêu, chuyển sang điểm tiếp theo
        if (distance <= 0.1f)
        {
            _TargetPoint = path.GetNextPoint();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
{
    // Kiểm tra nếu đối tượng va chạm có tag là "Player"
    if (collision.gameObject.tag == "Player")
    {
        // Gán Player thành con của platform
        collision.transform.parent = transform;
    }
}

public void OnCollisionExit2D(Collision2D collision)
{
    // Kiểm tra nếu đối tượng va chạm có tag là "Player"
    if (collision.gameObject.tag == "Player")
    {
        // Hủy bỏ mối quan hệ cha-con
        collision.transform.parent = null;
    }
}

}
