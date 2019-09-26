using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]
    private Dialog m_Dialog;

    [SerializeField]
    private KeyCode m_KeyCode = KeyCode.C;

    private void Update()
    {
        if (Input.GetKeyDown(m_KeyCode))
        {
            DialogManager.Instance.BeginDialog(m_Dialog);
        }
    }
}
