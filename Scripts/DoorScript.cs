using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public static DoorScript Instance;
    private Animator anim;
    private BoxCollider2D box;
 
    public GameObject exit;
    [HideInInspector]
    public int CollectablesCount;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        if(Instance == null)
        {
            Instance = this;
        }
        box.isTrigger = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(Instantiate(exit, collision.transform.position, Quaternion.identity), 1f);/**/
            SceneManager.LoadScene("Winner");
            AudioManager.Instance.Win();

        }
    }

}
