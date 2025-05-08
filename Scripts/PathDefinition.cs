using UnityEngine;

public class PathDefinition : MonoBehaviour
{
    // Mảng các điểm định nghĩa đường đi
    public Transform[] listPoint;

    // Biến dùng để theo dõi vị trí hiện tại trong mảng và hướng di chuyển
    private int startAt = 0;
    private int directionMove = 1;

    // Vẽ Gizmos trong Editor để hiển thị đường đi
    private void OnDrawGizmos()
    {
        if (listPoint == null || listPoint.Length < 2)
            return;

        for (int i = 1; i < listPoint.Length; i++)
        {
            Gizmos.DrawLine(listPoint[i - 1].position, listPoint[i].position);
        }
    }

    // Trả về điểm tại vị trí p trong mảng listPoint
    public Transform GetPointAt(int p)
    {
        return listPoint[p];
    }

    // Lấy điểm tiếp theo dựa vào hướng di chuyển hiện tại
    public Transform GetNextPoint()
    {
        // Nếu đang ở điểm đầu tiên, hướng di chuyển sang phải (tăng chỉ số)
        if (startAt == 0)
        {
            directionMove = 1;
        }
        // Nếu đang ở điểm cuối, hướng di chuyển ngược lại (giảm chỉ số)
        else if (startAt == listPoint.Length - 1)
        {
            directionMove = -1;
        }

        // Cập nhật vị trí hiện tại
        startAt += directionMove;
        return listPoint[startAt];
    }
}
