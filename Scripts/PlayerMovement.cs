using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 1.0f;

    public void Move(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * m_Speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    public void Turning(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);

        if (direction.magnitude != 0.0f)
        {
            Quaternion angle = Quaternion.LookRotation(direction);

            transform.rotation = angle;
        }
    }
}