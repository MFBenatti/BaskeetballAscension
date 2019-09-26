using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private TextAsset m_CreditsTextAsset;

    [SerializeField]
    private Text m_CreditsText;

    [SerializeField]
    private Canvas m_CreditsCanvas;

    [Header("Role")]
    [SerializeField]
    private int m_RoleFontSize = 80;

    [SerializeField]
    private bool m_RoleTextCapitalized;

    [Header("Employee")]
    [SerializeField]
    private int m_EmployeeFontSize = 50;

    [SerializeField]
    private bool m_EmployeeTextCapitalized;

    [Header("Space")]
    [SerializeField]
    private int m_SpaceSize = 40;

    [Header("Movement")]
    [Range(0.0001f, 1.0f)]
    [SerializeField]
    private float m_SmoothTime = 0.1f;

    [SerializeField]
    private float m_Time = 5.0f;

    public void Start()
    {
        string[] lines = m_CreditsTextAsset.text.Replace("\r", "").Split('\n');
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            if (line.Contains("t:"))
            {
                line = line.Replace("t:", "");

                if (m_RoleTextCapitalized)
                {
                    line = line.ToUpperInvariant();
                }

                line = $"<b><size={m_RoleFontSize}>{line}</size></b>";
            }
            else
            {
                if (m_EmployeeTextCapitalized)
                {
                    line = line.ToUpperInvariant();
                }

                line = $"<size={m_EmployeeFontSize}>{line}</size>";
            }

            builder.Append(line).Append($"<size={m_SpaceSize}>\n</size>");
        }

        m_CreditsText.text = builder.ToString();
        Canvas.ForceUpdateCanvases();

        StartCoroutine(Animate());
    }

    public IEnumerator Animate()
    {
        yield return null;

        RectTransform canvasTransform = m_CreditsCanvas.GetComponent<RectTransform>();

        Vector3 from = m_CreditsText.rectTransform.anchoredPosition3D;
        Vector3 to = m_CreditsText.rectTransform.anchoredPosition3D;
        to.y += m_CreditsText.rectTransform.sizeDelta.y + canvasTransform.rect.size.y;

        m_Time = (to.y - from.y) * m_SmoothTime;

        yield return StartCoroutine(Move(from, to));
    }

    public IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime / m_Time < 1.0f)
        {
            elapsedTime += Time.deltaTime;

            float time = Mathf.Clamp01(elapsedTime / m_Time);
            m_CreditsText.rectTransform.anchoredPosition3D = Vector3.Lerp(from, to, time);

            yield return null;
        }

        m_CreditsText.rectTransform.anchoredPosition3D = to;
        ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, null, ExecuteEvents.submitHandler);
    }
}