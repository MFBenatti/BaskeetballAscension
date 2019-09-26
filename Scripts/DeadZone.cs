using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public float m_Delay = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointManager.Instance.Respawn(other.gameObject, m_Delay);
        }
    }
}
