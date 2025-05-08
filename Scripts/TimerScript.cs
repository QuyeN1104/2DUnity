using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI; 

public class TimerScript : MonoBehaviour
{
    public Slider slider; 

    private GameObject player;
    public float time = 100f;
    public float timeBurn = 1f;

    private void Awake()
    {
        player = GameObject.Find("Player");
        //slider = GameObject.Find("Timer Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = time;
        slider.value = time;
    }

    private void Update()
    {
        if (!player) return;
        if (time > 0f)
        {
            time -= timeBurn * Time.deltaTime;
            slider.value = time;
        }
        else
        {
            slider.value = 0f;
            Destroy(player);
            GameObject.Find("Player").GetComponent<Player>().Die();
        }
    }
}
