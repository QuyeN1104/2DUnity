using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public GameObject pausePanel;
    public Button buttonResume;
    public Button buttonBackMenu;

    private void Start()
    {
        // Gán sự kiện cho nút Resume và BackMenu
        buttonResume.onClick.AddListener(ResumeGame);
        buttonBackMenu.onClick.AddListener(BackMenu);

        // Ẩn panel khi bắt đầu
        pausePanel.SetActive(false);
    }

    public void PlayerDie()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Dừng game
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Tiếp tục game
        //SceneManager.LoadScene(""); // Chuyển sang scene khác (nếu cần)
    }

    public void BackMenu()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene"); // Về menu
    }
}
