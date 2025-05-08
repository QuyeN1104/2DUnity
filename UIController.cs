using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI txtScore;

    // Update is called once per frame
    void Update()
    {
            txtScore.text = "The Score is: " + DiamondScript.score;
    }
}
