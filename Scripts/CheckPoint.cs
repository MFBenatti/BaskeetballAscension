using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public enum CheckPointState { Inactive, Active };

    public CheckPointState m_State = CheckPointState.Inactive;

    public void Start()
    {
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && m_State == CheckPointState.Inactive)
        {
            m_State = CheckPointState.Active;
            //CheckPointManager.Instance.Position = other.transform.position;
            PlayerPrefs.SetString("check_point", JsonUtility.ToJson(other.transform.position));
        }
    }
}
