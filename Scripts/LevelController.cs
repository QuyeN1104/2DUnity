using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
   

    public void Back()
    {
        SceneManager.LoadScene("Menu");
        DiamondScript.score = 0;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
