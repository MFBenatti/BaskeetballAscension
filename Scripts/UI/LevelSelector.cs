using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [Header("Properties")]
    public Sprite m_LevelSprite;
    public Sprite m_LockedLevelSprite;
    public string m_LevelName;
    public bool m_Completed;
    public int m_Stars;
    public bool m_Locked;

    [Header("User Interface (UI)")]
    public Image m_SourceImage;
    public Image m_LockedImage;
    public Text m_LevelNameText;
    public Image m_StarsImage;
    public Button m_LevelButton;

    private void Locked()
    {
        m_Locked = true;
        m_LockedImage.enabled = true;
        m_LevelButton.enabled = false;
    }

    private void Unlocked()
    {
        m_Locked = false;
        m_LockedImage.enabled = false;
        m_LevelButton.enabled = true;
    }

    public void Complete()
    {
        m_Completed = true;
    }

    public void Complete(int stars)
    {
        m_Completed = true;
        m_Stars = stars;
        m_StarsImage.fillAmount = stars / 3.0f;
    }

    public string m_SceneName;

    private void Start()
    {
        m_LevelNameText.text = m_LevelName;
        m_SourceImage.sprite = m_LevelSprite;
        m_LockedImage.sprite = m_LockedLevelSprite;

        m_LevelButton.onClick.RemoveAllListeners();
        m_LevelButton.onClick.AddListener(
            delegate {
                ScreenManager.Instance.LoadLevelLoading(m_SceneName);
            }
        );

        m_LockedImage.enabled = m_Locked;
        m_LevelButton.enabled = !m_Locked;
        m_StarsImage.fillAmount = m_Stars / 3.0f;
        m_Completed = m_Stars > 0;
    }
}
