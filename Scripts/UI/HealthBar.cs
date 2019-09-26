using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("User Interface")]
    [SerializeField]
    private Image m_BarImage;

    [SerializeField]
    private Text m_BarText;

    [Header("Settings")]
    [SerializeField]
    private float m_MaxValue;

    [SerializeField]
    private bool m_UseTime;

    [SerializeField]
    private float m_TimeToFill;

    public float Value { get; private set; }

    private float m_ElapsedTime;

    public void Start()
    {
        Value = 1;
        SetHealth(m_MaxValue);
    }

    public void SetHealth(float health)
    {
        if (m_UseTime)
        {
            float value = Value * m_MaxValue;
            StartCoroutine(ChangeHealth(value, health));
        }
        else
        {
            UpdateHealth(health);
        }
    }

    public void UpdateHealth(float health)
    {
        Value = health / m_MaxValue ;
        m_BarImage.fillAmount = Value;
        m_BarText.text = string.Format("{0:0} / {1:0}", Value * m_MaxValue, m_MaxValue);
    }

    private IEnumerator ChangeHealth(float fromValue, float toValue)
    {
        m_ElapsedTime = 0.0f;

        while (m_ElapsedTime / m_TimeToFill < 1.0f)
        {
            m_ElapsedTime += Time.deltaTime;
            float value = Mathf.Lerp(fromValue, toValue, m_ElapsedTime / m_TimeToFill);
            UpdateHealth(value);
            yield return null;
        }

        UpdateHealth(toValue);
    }
}