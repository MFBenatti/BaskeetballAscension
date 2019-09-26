using UnityEngine;

public class StayInsideMinimapCircle : MonoBehaviour
{
    private Camera m_MinimapCam;

    private Vector3 m_ParentPosition;

    private SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private Color m_InsideIconColor = new Color(0.90f, 0.29f, 0.23f, 1.0f);

    [SerializeField]
    private Color m_OutsideIconColor = new Color(0.94f, 0.76f, 0.05f, 1.0f);

    private void Start()
    {
        m_MinimapCam = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>();

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        m_ParentPosition = transform.parent.transform.position;
        m_ParentPosition.y = transform.position.y;

        transform.position = m_ParentPosition;
    }

    private void LateUpdate()
    {
        Vector3 centerMinimapPosition = m_MinimapCam.transform.localPosition;
        centerMinimapPosition.y -= 0.5f;

        float distance = Vector3.Distance(transform.position, centerMinimapPosition);

        float minimapSize = m_MinimapCam.orthographicSize * 0.9f;

        if (distance > minimapSize)
        {
            Vector3 fromOriginToObject = transform.position - centerMinimapPosition;
            fromOriginToObject *= minimapSize / distance;

            transform.position = centerMinimapPosition + fromOriginToObject;

            m_SpriteRenderer.color = m_OutsideIconColor;
        }
        else
        {
            m_SpriteRenderer.color = m_InsideIconColor;
        }
    }
}
