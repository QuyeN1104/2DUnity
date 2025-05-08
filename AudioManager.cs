using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip collect;
    public AudioClip die;
    public AudioClip bullet;
    public AudioClip jump;
    public AudioClip win;



    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không bị hủy khi chuyển scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    /// <summary>
    /// Phát nhạc nền
    /// </summary>
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    /// <summary>
    /// Phát một âm thanh hiệu ứng theo index
    /// </summary>
    public void Collect()
    {
        if(collect != null)
            sfxSource.PlayOneShot(collect);
    }
    public void Win()
    {
        if (win != null)
            sfxSource.PlayOneShot(win);
    }

    public void Jump()
    {
        if (collect != null)
            sfxSource.PlayOneShot(jump);
    }
    public void Die()
    {
        if (collect != null)
            sfxSource.PlayOneShot(die);
    }
    public void Bullet()
    {
        if(bullet != null)
            sfxSource.PlayOneShot(bullet);
    }
}
