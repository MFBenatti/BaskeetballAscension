using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

   // [SerializeField]
   // private KeyCode m_KeyToPause = KeyCode.Escape;

    [SerializeField]
    private GameObject m_PausePanel;

    public bool IsPaused { get; private set; }

    public void TogglePause()
    {
        if (!IsPaused)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Show()
    {
        m_PausePanel.SetActive(true);
        IsPaused = !IsPaused;
        Time.timeScale = 0.0f;
    }

    public void Hide()
    {
        m_PausePanel.SetActive(false);
        IsPaused = !IsPaused;
        Time.timeScale = 1.0f;
    }
}