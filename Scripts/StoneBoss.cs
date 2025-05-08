using System.Collections;
using UnityEngine;

public class StoneBoss : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Vector3 startPos, endPos, nextPos;
    [SerializeField] private Transform posB;
    private Animator anim;

    [SerializeField] private float timeAttack = 0;
    private bool normalAttack = true;
    private float timeHeavy, timeNormal;

    [SerializeField] private GameObject zombie;

    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = transform.localPosition;
        endPos = posB.localPosition;
        nextPos = endPos;

        timeHeavy = Random.Range(7f, 10f);
        timeNormal = Random.Range(2f, 5f);

        StartCoroutine(Spawner());
    }

    void Update()
    {
        Running();
        CheckAttack();
    }

    void Running()
    {
        anim.SetTrigger("Move");
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.localPosition, nextPos) <= 0.1f)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        nextPos = (nextPos.x != startPos.x) ? startPos : endPos;
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }

    void CheckAttack()
    {
        timeAttack += Time.deltaTime;

        if (timeAttack >= timeHeavy)
        {
            anim.SetTrigger("HeavyAtt");
            timeAttack = 0;
            normalAttack = true;
            timeHeavy = Random.Range(7f, 10f);
        }
        else if (timeAttack >= timeNormal && normalAttack)
        {
            anim.SetTrigger("NormalAtt");
            normalAttack = false;
            timeNormal = Random.Range(2f, 5f);
        }
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(2f);
        Vector2 pos = transform.position;
        pos.x += transform.localScale.x;
        Instantiate(zombie, pos, transform.rotation);
        StartCoroutine(Spawner());
    }
}
