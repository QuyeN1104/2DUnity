using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController1 : MonoBehaviour
{
    public void PlayLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
