using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    private Camera m_Camera;

    private void Start()
    {
        m_Camera = Camera.main;
    }

    public void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward, m_Camera.transform.rotation * Vector3.up);
    }
}
