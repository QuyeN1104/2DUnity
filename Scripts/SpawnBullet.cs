using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab của viên đạn
    public float spawnX = -13; // Vị trí X cố định để spawn
    public float minY = -3f; // Giới hạn dưới trục Y
    public float maxY = 3f;  // Giới hạn trên trục Y

    private void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        while (true)
        {
            float randomY = Random.Range(minY, maxY); // Tạo vị trí Y ngẫu nhiên
            Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);

            Instantiate(bulletPrefab, spawnPosition, gameObject.transform.rotation);

            float randomDelay = Random.Range(1f, 2f); // Thời gian ngẫu nhiên từ 2-3s
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
