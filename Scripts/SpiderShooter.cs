using UnityEngine;
using System.Collections;

public class Spidershooter : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            float delay = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(delay);
            Instantiate(bullet, this.transform.position - new Vector3(0, 0.5f, 0), transform.rotation);
        }
    }
}
