using UnityEngine;

public class MinimapCameraFolow : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_Height = 50.0f;

    public void LateUpdate()
    {
        Vector3 position = m_Target.position;
        position.y += m_Height;

        transform.position = position;
        transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
    }
}
